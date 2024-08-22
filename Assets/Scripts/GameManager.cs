using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 遊戲管理器
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<GameManager>(); 
                return _instance;            
            }
        }
        private static GameManager _instance;

        [SerializeField, Header("Fungus 開頭與教學")]
        private GameObject goFungusStartTutorial;
        [SerializeField, Header("結束畫面淡入間隔"), Range(0, 0.1f)]
        private float fadeInInterval;

        private WaitForSeconds waitFadeInInterval;
        private ControlSystem controlSystem;
        /// <summary>
        /// 圖片結束畫面
        /// </summary>
        private CanvasGroup groupFinal;
        /// <summary>
        /// 按鈕重新遊戲、按鈕離開遊戲
        /// </summary>
        private Button btnReplay, btnQuit;
        /// <summary>
        /// 文字結束標題
        /// </summary>
        private TMP_Text textFinal;

        private void Awake()
        {
            // 想要抓的元件在場景上只有一個可以使用此寫法，例如：控制系統只有一個
            // 透過類型(元件)尋找物件
            // 找到場請上有 ControlSystem 的物件 並 儲存在 controlSystem 變數
            controlSystem = FindObjectOfType<ControlSystem>();

            groupFinal = GameObject.Find("圖片結束畫面").GetComponent<CanvasGroup>();
            btnReplay = GameObject.Find("按鈕重新遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("按鈕離開遊戲").GetComponent<Button>();
            textFinal = GameObject.Find("文字結束標題").GetComponent<TMP_Text>();

            // 重新遊戲按鈕 點擊後 會執行 Replay 功能
            btnReplay.onClick.AddListener(Replay);
            // 離開遊戲按鈕 點擊後 會執行 Quit 功能
            btnQuit.onClick.AddListener(Quit);
            
            // 初始化等待淡入間隔 節省效能 (new 重複使用會吃效能)
            waitFadeInInterval = new WaitForSeconds(fadeInInterval);

            // 測試：發佈遊戲前刪除
            Test();
        }

        /// <summary>
        /// 開始淡入
        /// </summary>
        public void StartFadeIn()
        {
            StartCoroutine(FadeIn());
        }

        /// <summary>
        /// 淡入結束畫面
        /// </summary>
        private IEnumerator FadeIn()
        {
            // 執行十次
            for (int i = 0; i < 10; i++)
            {
                // 透明度累加 0.1
                groupFinal.alpha += 0.1f;
                // 等待
                yield return waitFadeInInterval;
            }
            // 啟動互動與遮擋
            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }

        private void Replay()
        {
            // 場景管理器 載入場景(場景名稱)
            // SceneManager.GetActiveScene().name 取得當前場景的名稱
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Quit()
        {
            // 應用程式的離開 (僅在 PC、手機等執行檔有作用)
            Application.Quit();
            print("<color=#f33>離開遊戲</color>");
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
