using UnityEngine;

namespace KID
{
    // 要求元件，在套用此腳本到物件時會執行一次
    // 套用音效管理器到物件會自動添加一個 AduioSource 音效來源元件
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<SoundManager>();
                return _instance;
            }
        }
        private static SoundManager _instance;

        [SerializeField, Header("音效")]
        private AudioClip[] sounds;

        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="soundType">音效類型</param>
        /// <param name="min">最小音量</param>
        /// <param name="max">最大音量</param>
        public void PlaySound(SoundType soundType, float min = 0.7f, float max = 1.2f)
        {
            // 獲得隨機音量
            float volume = Random.Range(min, max);
            // 透過類型獲得音效
            // 列舉前面添加 (int) 可以取得該列舉的編號
            AudioClip sound = sounds[(int)soundType];
            // 音效來源.播放一次音效(音效，音量)
            aud.PlayOneShot(sound, volume);
        }
    }

    // 定義列舉 enumeration：(類似單選)
    // 注意要與陣列順序相同
    /// <summary>
    /// 0 吃道具、1 掉落道具、2 攻擊_1、3 攻擊_2、
    /// 4 敵人受傷、5 敵人死亡、
    /// 6 施放技能_1、7 玩家受傷、8 玩家死亡
    /// </summary>
    public enum SoundType
    {
        EatProp, DropProp, Attack1, Attack2,
        EnemyHurt, EnemyDead,
        Skill1, PlayerHurt, PlayerDead
    }
}
