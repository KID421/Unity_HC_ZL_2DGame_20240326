using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        #region 資料區域
        [SerializeField, Header("敵人資料")]
        private DataEnemy dataEnemy;
        [SerializeField, Header("可被攻擊的圖層")]
        private LayerMask layerCanAttack = 1 << 6;

        private Transform player;
        private string playerName = "玩家_騎士";
        private float angleRight = 0;
        private float angleLeft = 180;
        private Rigidbody rig;
        private Animator ani;
        private string parMove = "移動數值";
        private string parAttack = "觸發攻擊";
        private bool isAttacking;
        private bool startCheckAttackArea;

        private float xDistance => Mathf.Abs(player.position.x - transform.position.x);
        private float zDistance => Mathf.Abs(player.position.z - transform.position.z);
        #endregion

        #region 事件區域
        private void OnDrawGizmos()
        {
            // transform.TransformDirection() 區域座標與世界座標轉換
            // 如果 還沒有開始檢查攻擊區域 就跳出
            if (!startCheckAttackArea) return;

            Gizmos.color = new Color(1, 0.7f, 0.5f, 0.5f);
            Gizmos.DrawCube(
                transform.position +
                transform.TransformDirection(dataEnemy.attackAreaOffset),
                dataEnemy.attackAreaSize);
        }

        private void Awake()
        {
            // 透過名稱搜尋遊戲物件
            // 搜尋場景上名稱為"玩家_騎士"物件的變形資訊 存放到 player
            player = GameObject.Find(playerName).transform;

            rig = GetComponent<Rigidbody>();
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Flip();
            TrackPlayerZ();
            TrackPlayerX();
            UpdateMoveAnimation();
            Attack();
            CheckAttackArea();
        }
        #endregion

        #region 方法區域
        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            // 如果在攻擊中就跳出不翻面
            if (isAttacking) return;
            float angle = player.position.x < transform.position.x ? angleLeft : angleRight;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        /// <summary>
        /// 追蹤玩家的 Z 軸
        /// </summary>
        private void TrackPlayerZ()
        {
            // 如果在攻擊中就跳出不追蹤Z
            if (isAttacking) return;
            // 如果 Z 軸距離 <= Z 軸停止距離 就 跳出
            if (zDistance <= dataEnemy.stopDistanceZ) return;

            // 如果 玩家 的 Z 軸 > 敵人 的 Z 軸，方向 +1 ，否則 方向 -1
            float direction = player.position.z > transform.position.z ? +1 : -1;
            // print($"<color=#f33>敵人 Z 軸的方向 {direction}</color>");

            // 剛體的加速度 = 新三維向量(剛體加速度X，剛體加速度Y，方向 * 移動速度 Z 軸)
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, direction * dataEnemy.moveSpeedZAxis);
        }

        /// <summary>
        /// 追蹤玩家的 X 軸
        /// </summary>
        private void TrackPlayerX()
        {
            // 如果在攻擊中就跳出不追蹤X
            if (isAttacking) return;
            if (xDistance <= dataEnemy.stopDistanceX) return;

            rig.velocity =
                transform.right * dataEnemy.moveSpeedXAxis +
                Vector3.up * rig.velocity.y +
                Vector3.forward * rig.velocity.z;
        }

        /// <summary>
        /// 更新移動動畫
        /// </summary>
        private void UpdateMoveAnimation()
        {
            ani.SetFloat(parMove, rig.velocity.magnitude / dataEnemy.moveSpeedXAxis);
        }

        /// <summary>
        /// 攻擊
        /// </summary>
        private void Attack()
        {
            // 如果 在攻擊中 就 跳出
            if (isAttacking) return;

            // && 並且，輸入方式 Shift + 7
            // 如果 x 距離 <= 攻擊距離 x 並且 z 距離 <= 攻擊距離 z 才會攻擊
            if (xDistance <= dataEnemy.attackStopDistanceX && zDistance <= dataEnemy.stopDistanceZ)
            {
                // 啟動協同程序 (開始攻擊())
                StartCoroutine(StartAttack());
            }
        }

        /// <summary>
        /// 開始攻擊
        /// </summary>
        private IEnumerator StartAttack()
        {
            isAttacking = true;
            ani.SetTrigger(parAttack);
            yield return new WaitForSeconds(dataEnemy.attackBeforeTime);
            startCheckAttackArea = true;
            yield return new WaitForSeconds(dataEnemy.attackTime);
            startCheckAttackArea = false;
            yield return new WaitForSeconds(dataEnemy.attackAfterTime);
            isAttacking = false;
        }

        /// <summary>
        /// 檢查攻擊區域
        /// </summary>
        private void CheckAttackArea()
        {
            // 如果 還沒有開始檢查攻擊區域 就跳出
            if (!startCheckAttackArea) return;
            // 碰到的物件 = 物理.繪製方塊(此物件座標+攻擊位移，尺寸/2，零角度)
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.TransformDirection(dataEnemy.attackAreaOffset),
                dataEnemy.attackAreaSize / 2, Quaternion.identity, layerCanAttack);

            // 如果擊中的物件數量超過 0 個
            if (hits.Length > 0)
            {
                // 攻擊浮動 = 隨機的範圍(0，攻擊力 * 浮動百分比)
                float attackFloat = Random.Range(0, dataEnemy.attack * dataEnemy.attackFloatValue);
                // 攻擊力 = 攻擊力 + 攻擊浮動
                float attack = dataEnemy.attack + attackFloat;
                // 取整數
                attack = Mathf.FloorToInt(attack);
                // 對擊中物件造成傷害(攻擊力)
                hits[0].gameObject.GetComponent<HpPlayer>().Damage(attack);
            }
        }
        #endregion
    }
}
