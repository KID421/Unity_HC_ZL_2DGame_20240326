using System;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 道具管理器：吃道具以及處理吃道具後的行為
    /// </summary>
    public class PropManager : MonoBehaviour
    {
        // 常用設計模式：單例模式 - 此系統在遊戲內只有一個存在並且需要被其他人存取
        // 公開靜態 instance 單例模式：允許外部存取
        public static PropManager instance
        {
            // 獲得單例模式的實體物件
            get
            {
                // 如果 _instance 是空的
                if (_instance == null)
                { 
                    // 就尋找場景上帶有 PropManager 的實體並儲存到 _instnace;
                    _instance = FindObjectOfType<PropManager>();
                }
                // 傳回 _instance
                return _instance;
            }
        }
        // 用來儲存 PropManager 資料的變數
        private static PropManager _instance;

        // 事件 event：在特定時間點會被執行的程式，可以讓需要的系統訂閱並做出回饋
        // 事件習慣用 on 開頭
        // 吃到血量道具與魔力道具的事件
        public event EventHandler<float> onEatHp;
        public event EventHandler<float> onEatMp;

        private string propName = "道具";
        // 放在 switch 要添加 const 常數，常數為不能改變的值
        private const string propHp = "道具_血量藥水(Clone)";
        private const string propMp = "道具_魔力藥水(Clone)";

        // 碰撞事件 OCE
        // 碰到物件後會執行一次
        // collision 會儲存碰到物件的碰撞資訊
        private void OnCollisionEnter(Collision collision)
        {
            // 如果 碰到物件的名稱 有"道具"這兩個字
            if (collision.gameObject.name.Contains(propName))
            {
                float value = collision.gameObject.GetComponent<Prop>().value;
                EatProp(collision.gameObject.name, value);
                // 刪除道具物件
                Destroy(collision.gameObject);
            }
        }

        /// <summary>
        /// 吃道具功能：觸發吃道具事件
        /// </summary>
        /// <param name="prop">道具名稱</param>
        private void EatProp(string prop, float value)
        {
            // 音效管理器的實體物件 執行 播放音效功能
            SoundManager.instance.PlaySound(SoundType.EatProp, 0.8f, 1.3f);

            // switch 判斷式
            switch (prop)
            {
                case propHp:
                    // 呼叫事件(執行事件者，傳出去的資料)
                    // ? 如果沒有人訂閱就不呼叫
                    onEatHp?.Invoke(this, value);
                    break;
                case propMp:
                    onEatMp?.Invoke(this, value);
                    break;
            }
        }
    }
}
