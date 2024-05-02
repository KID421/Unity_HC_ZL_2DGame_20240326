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
        [SerializeField, Header("剛體元件")]
        private Rigidbody rig;
        [SerializeField, Header("動畫元件")]
        private Animator ani;

        // string 字串：存放文字資料
        private string parMove = "移動數值";
        private string parJump = "觸發跳躍"; 
        #endregion

        // 喚醒事件：播放遊戲後會執行一次
        private void Awake()
        {
        }

        // 開始事件：喚醒事件後執行一次
        private void Start()
        {
        }

        // 更新事件：開始事件後一秒約 60 次
        private void Update()
        {
            // 軸向名稱
            // 上下 WS - 垂直 Vertical
            // 左右 AD - 水平 Horizontal
            // 左 A -1，右 D +1，沒按 0

            // 區域變數 h = 輸入 的 取得軸向 (軸向名稱)
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            MoveAndAnimation(h, v);
            Flip(h);
        }

        /// <summary>
        /// 翻面方法
        /// </summary>
        /// <param name="h">玩家的水平軸向</param>
        private void Flip(float h)
        {
            // 如果 h > 0 角度設定為 0 (右邊)
            // 如果 h < 0 角度設定為 180 (左邊)
            // 三元運算子
            // 布林值 ? 布林值為真結果 : 布林值為假結果

            // 如果 h 絕對值 後 < 0.1 就 跳出
            if (Mathf.Abs(h) < 0.1f) return;

            // 整數 角度 = 當 h > 0 結果 0 度角，否則 180 度角
            int angle = h > 0 ? 0 : 180;

            // 控制角度的方式
            // transform 此物件的變形資訊：座標、角度與尺寸
            // eulerAngles 歐拉角度
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        /// <summary>
        /// 移動與動畫
        /// </summary>
        /// <param name="h">玩家的水平軸向</param>
        /// <param name="v">玩家的垂直軸向</param>
        private void MoveAndAnimation(float h, float v)
        {
            // 剛體 的 加速度 = 三維向量
            rig.velocity = new Vector3(h, 0, v) * moveSpeed;

            // magnitude 將三維向量轉為浮點數
            // 動畫 的 設定浮點數(參數名稱，浮點數值)
            ani.SetFloat(parMove, rig.velocity.magnitude / moveSpeed);
        }
    }
}
