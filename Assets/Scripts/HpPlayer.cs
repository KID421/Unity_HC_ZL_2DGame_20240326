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
        [SerializeField, Header("控制系統")]
        private ControlSystem controlSystem;

        private void Start()
        {
            UpdateUI();
            // 獲得單例模式：腳本名稱.instance.成員 (公開的變數、方法...)
            PropManager.instance.onEatHp += EatHpProp;
        }

        private void EatHpProp(object sender, float e)
        {
            print($"<color=#f3d>玩家血量系統：開始補血 {e}</color>");
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
            // 覆類別原本的內容
            base.Damage(damage);
            UpdateUI();
        }

        protected override void Dead()
        {
            base.Dead();
            // 關閉控制系統
            controlSystem.enabled = false;
        }
    }
}
