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

        private void Start()
        {
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
    }
}
