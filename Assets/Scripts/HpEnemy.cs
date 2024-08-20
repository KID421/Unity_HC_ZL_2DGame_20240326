using UnityEngine;

namespace KID
{
    /// <summary>
    /// 血量系統：敵人
    /// </summary>
    public class HpEnemy : HpSystem
    {
        private ShadowEnemy shadowEnemy;
        private EnemySystem enemySystem;
        private BoxCollider boxCollider;
        private Rigidbody rig;

        private DataHpEnemy dataHpEnemy;

        private void Start()
        {
            // 將舊的血量資料轉為新的敵人血量資料
            dataHpEnemy = (DataHpEnemy)dataHp;
            // 取得此物件身上的 ShadowEnemy
            shadowEnemy = GetComponent<ShadowEnemy>();
            enemySystem = GetComponent<EnemySystem>();
            boxCollider = GetComponent<BoxCollider>();
            rig = GetComponent<Rigidbody>();
        }

        public override void Damage(float damage)
        {
            base.Damage(damage);
            SoundManager.instance.PlaySound(SoundType.EnemyHurt, 0.8f, 1.3f);
        }

        protected override void Dead()
        {
            base.Dead();
            Destroy(gameObject, 1.3f);
            // 刪除影子
            shadowEnemy.DestroyShadow(1.3f);
            // 關閉 敵人系統 與 碰撞器
            enemySystem.enabled = false;
            boxCollider.enabled = false;
            // 約束 剛體 全部的凍結
            rig.constraints = RigidbodyConstraints.FreezeAll;

            SoundManager.instance.PlaySound(SoundType.EnemyDead, 0.8f, 1.3f);
            DropObject();
        }

        private void DropObject()
        {
            // 迴圈重複執行全部的掉落物件
            // dataHpEnemy.dropObjects.Length 掉落物件的數量
            for (int i = 0; i < dataHpEnemy.dropObjects.Length; i++)
            {
                // 拿出掉落物件的資料
                // var 沒有變數類型
                var dropObject = dataHpEnemy.dropObjects[i];
                // 如果 隨機值 小於等於 掉落物件的機率
                // Random.value 傳回介於 0 ~ 1 之間的隨機數字，例如：0.1, 0.22, 0.9
                if (Random.value <= dropObject.probability)
                {
                    SoundManager.instance.PlaySound(SoundType.DropProp);

                    // 就生成掉落物件
                    GameObject tempDrop = Instantiate(
                        dropObject.prefab,
                        transform.position + Vector3.up * dropObject.offsetY,
                        Quaternion.identity);

                    // 獲得推力的向上與左右隨機值
                    float randomUp = Random.Range(dataHpEnemy.upMin, dataHpEnemy.upMax);
                    float randomHorizontal = Random.Range(dataHpEnemy.horizontalMin, dataHpEnemy.horizontalMax);
                    // 獲得道具的剛體並添加推力
                    tempDrop.GetComponent<Rigidbody>().AddForce(new Vector3(randomHorizontal, randomUp, 0));
                }
            }
        }
    }
}
