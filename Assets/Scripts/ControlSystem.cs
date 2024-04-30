using UnityEngine;

namespace KID
{
    public class ControlSystem : MonoBehaviour
    {
        #region 資料區域
        // private 私人：只有這個腳本可以存取的資料
        // float 浮點數：存放小數點資料
        // SerializeField 序列化欄位：顯示此資料在屬性面板
        // Header 標題：在屬性面板上顯示標題文字
        [SerializeField, Header("移動速度"), Range(0, 50)]
        private float moveSpeed = 3.5f;
        [SerializeField, Header("跳躍高度"), Range(0, 1000)]
        private float jump = 350;

        // string 字串：存放文字資料
        private string parMove = "移動數值";
        private string parJump = "觸發跳躍"; 
        #endregion

        // 喚醒事件：播放遊戲後會執行一次
        private void Awake()
        {
            //print("哈囉，沃德 :D");
            //print("<color=yellow>喚醒事件</color>");
        }

        // 開始事件：喚醒事件後執行一次
        private void Start()
        {
            //print("<color=red>開始事件</color>");
        }

        // 更新事件：開始事件後一秒約 60 次
        private void Update()
        {
            //print("<color=green>更新事件</color>");
        }
    }
}
