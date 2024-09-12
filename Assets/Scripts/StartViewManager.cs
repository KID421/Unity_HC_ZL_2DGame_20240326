using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace KID
{
    /// <summary>
    /// 開始畫面管理器
    /// </summary>
    public class StartViewManager : MonoBehaviour
    {
        private Button btnPlay, btnQuit;

        private void Awake()
        {
            btnPlay = GameObject.Find("按鈕開始遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("按鈕離開遊戲").GetComponent<Button>();
            btnPlay.onClick.AddListener(StartGame);
            btnQuit.onClick.AddListener(QuityGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("遊戲場景");
        }

        private void QuityGame()
        {
            Application.Quit();
        }
    }
}
