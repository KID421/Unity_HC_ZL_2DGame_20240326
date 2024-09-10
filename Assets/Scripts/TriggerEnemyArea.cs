using UnityEngine;

namespace KID
{
    /// <summary>
    /// 觸發敵人區域：當玩家進入會生成敵人的區域
    /// </summary>
    public class TriggerEnemyArea : MonoBehaviour
    {
        private Animator ani;
        private string parFall = "觸發牆壁掉落";

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // 如果 碰到物件名稱包含 玩家 兩個字
            if (other.name.Contains("玩家"))
            {
                // 就觸發牆壁掉落動畫
                ani.SetTrigger(parFall);
            }
        }
    }
}
