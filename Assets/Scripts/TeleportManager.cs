using UnityEngine;

namespace KID
{
    /// <summary>
    /// 傳送陣管理器
    /// </summary>
    public class TeleportManager : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("玩家"))
            {
                GameOver();
            }
        }

        /// <summary>
        /// 遊戲結束
        /// </summary>
        private void GameOver()
        {
            GameManager.instance.StartFadeIn("挑戰成功");
        }
    }
}
