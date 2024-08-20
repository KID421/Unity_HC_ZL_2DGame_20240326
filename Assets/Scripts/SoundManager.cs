using UnityEngine;

namespace KID
{
    // 要求元件，在套用此腳本到物件時會執行一次
    // 套用音效管理器到物件會自動添加一個 AduioSource 音效來源元件
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField, Header("音效")]
        private AudioClip[] sounds;

        private AudioSource aud;

        // 定義列舉 enumeration：(類似單選)
        // 注意要與陣列順序相同
        /// <summary>
        /// 0 吃道具、1 掉落道具、2 攻擊_1、3 攻擊_2
        /// 4 敵人受傷、5 敵人死亡、6 施放技能_1、7 玩家受傷、8 玩家死亡
        /// </summary>
        private enum SoundType
        {
            EatProp, DropProp, Attack1, Attack2, EnemyHury, EnemyDead,
            Skill1, PlayerHurt, PlayerDead
        }

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        public void PlaySound(float min, float max)
        {

        }
    }
}
