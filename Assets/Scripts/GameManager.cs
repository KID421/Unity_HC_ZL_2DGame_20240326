using UnityEngine;

namespace KID
{
    /// <summary>
    /// 遊戲管理器
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField, Header("Fungus 開頭與教學")]
        private GameObject goFungusStartTutorial;

        private ControlSystem controlSystem;

        private void Awake()
        {
            // 想要抓的元件在場景上只有一個可以使用此寫法，例如：控制系統只有一個
            // 透過類型(元件)尋找物件
            // 找到場請上有 ControlSystem 的物件 並 儲存在 controlSystem 變數
            controlSystem = FindObjectOfType<ControlSystem>();

            // 測試：發佈遊戲前刪除
            Test();
        }

        /// <summary>
        /// 測試環境：關閉對話以及開啟移動與控制
        /// </summary>
        private void Test()
        {
            // 將 Fungus 開頭與教學 物件 隱藏 (失去作用)
            goFungusStartTutorial.SetActive(false);
            // 開啟控制器
            controlSystem.StartControl();
        }
    }
}
