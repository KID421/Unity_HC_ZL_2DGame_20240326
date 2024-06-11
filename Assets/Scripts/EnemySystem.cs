using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("移動速度"), Range(0, 10)]
        private float moveSpeed = 1.5f;

        private Transform player;
        private string playerName = "玩家_騎士";
        private float angleRight = 0;
        private float angleLeft = 180;
        private Rigidbody rig;
        private Animator ani;

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
        }

        /// <summary>
        /// 翻面
        /// </summary>
        private void Flip()
        {
            float angle = player.position.x < transform.position.x ? angleLeft : angleRight;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}
