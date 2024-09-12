using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 玩家血量系統
    /// </summary>
    public class HpPlayer : HpSystem
    {
        [SerializeField, Header("圖片血條")]
        private Image imgHp;
        [SerializeField, Header("文字血量")]
        private TMP_Text textHp;

        private ControlSystem controlSystem;
        private AttackSystem attackSystem;
        private SkillManager skillManager;

        private void Start()
        {
            controlSystem = GetComponent<ControlSystem>();
            attackSystem = GetComponent<AttackSystem>();
            skillManager = GetComponent<SkillManager>();

            UpdateUI();
            // 獲得單例模式：腳本名稱.instance.成員 (公開的變數、方法...)
            PropManager.instance.onEatHp += EatHpProp;
        }

        private void EatHpProp(object sender, float e)
        {
            // print($"<color=#f3d>玩家血量系統：開始補血 {e}</color>");
            hp += e;
            // 將血量夾在 0 ~ 最大值之間
            hp = Mathf.Clamp(hp, 0, hpMax);
            UpdateUI();
        }

        private void UpdateUI()
        {
            imgHp.fillAmount = hp / hpMax;
            textHp.text = $"血量 {hp}/{hpMax}";
        }

        // override 覆寫：覆寫覆類別有虛擬關鍵字的成員
        public override void Damage(float damage)
        {
            if (hp <= 0) return;
            if (isInvicible) return;
            SoundManager.instance.PlaySound(SoundType.PlayerHurt, 0.5f, 0.7f);
            // 覆類別原本的內容
            base.Damage(damage);
            UpdateUI();
        }

        protected override void Dead()
        {
            base.Dead();
            // 關閉控制、攻擊與技能系統
            controlSystem.enabled = false;
            attackSystem.enabled = false;
            skillManager.enabled = false;
            SoundManager.instance.PlaySound(SoundType.PlayerDead, 0.8f, 1.3f);
            // 呼叫 GM 的開始淡入
            GameManager.instance.StartFadeIn("挑戰失敗");
        }
    }
}
