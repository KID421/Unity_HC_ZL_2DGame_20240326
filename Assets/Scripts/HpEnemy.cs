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

        private void Start()
        {
            // 取得此物件身上的 ShadowEnemy
            shadowEnemy = GetComponent<ShadowEnemy>();
            enemySystem = GetComponent<EnemySystem>();
            boxCollider = GetComponent<BoxCollider>();
            rig = GetComponent<Rigidbody>();
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
        }
    }
}
