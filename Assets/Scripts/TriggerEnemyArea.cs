using UnityEngine;

namespace KID
{
    /// <summary>
    /// 觸發敵人區域：當玩家進入會生成敵人的區域
    /// </summary>
    public class TriggerEnemyArea : MonoBehaviour
    {
        [SerializeField, Header("要顯示的敵人")]
        private GameObject[] enemys;

        private Animator ani;
        private string parFall = "觸發牆壁掉落";
        private string parUp = "觸發牆壁上升";
        private int deadEnemyCount;

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // 如果 碰到物件名稱包含 玩家 兩個字
            if (other.name.Contains("玩家"))
            {
                // 關閉此物件的碰撞器
                GetComponent<Collider>().enabled = false;
                // 就觸發牆壁掉落動畫
                ani.SetTrigger(parFall);
                // 顯示全部的敵人
                for (int i = 0; i < enemys.Length; i++)
                {
                    enemys[i].SetActive(true);
                    enemys[i].GetComponent<HpEnemy>().onDead += EnemyDead;
                }
            }
        }

        private void EnemyDead(object sender, System.EventArgs e)
        {
            // 死亡敵人數量 +1
            deadEnemyCount++;
            // 如果 死亡敵人數量 等於陣列的數量
            if (deadEnemyCount == enemys.Length)
            {
                // 就將牆壁上升
                ani.SetTrigger(parUp);
            }
        }
    }
}
