using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy dataEnemy;

        private Transform player;
        private string playerName = "玩家_騎士";
        private float angleRight = 0;
        private float angleLeft = 180;
        private Rigidbody rig;
        private Animator ani;
        private string parMove = "移動數值";

        private float xDistance => Mathf.Abs(player.position.x - transform.position.x);
        private float zDistance => Mathf.Abs(player.position.z - transform.position.z);

        private void OnDrawGizmos()
        {
            // transform.TransformDirection() 區域座標與世界座標轉換

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
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            float angle = player.position.x < transform.position.x ? angleLeft : angleRight;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        /// <summary>
        /// 追蹤玩家的 Z 軸
        /// </summary>
        private void TrackPlayerZ()
        {
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

        private void Attack()
        {
            if (xDistance <= dataEnemy.attackStopDistance)
            {
                print("<color=#f11>開始攻擊!</color>");
            }
        }
    }
}
