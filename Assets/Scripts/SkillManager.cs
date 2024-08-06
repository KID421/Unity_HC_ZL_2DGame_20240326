using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 技能管理器
    /// </summary>
    public class SkillManager : MonoBehaviour
    {
        [SerializeField, Header("技能資料")]
        private DataSkill[] dataSkills;
        [SerializeField, Header("玩家魔力最大值"), Range(0, 1000)]
        private float mpMax = 500;
        [Header("魔力介面")]
        [SerializeField]
        private Image imgMp;
        [SerializeField]
        private TMP_Text textMp;

        private float mp;
        private Animator ani;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            mp = mpMax;
            UpdateUI();
        }

        private void Update()
        {
            SkillInput();
        }

        private void UpdateUI()
        {
            imgMp.fillAmount = mp / mpMax;
            textMp.text = $"魔力 {mp}/{mpMax}";
        }

        private void SkillInput()
        {
            // 如果魔力等於零就跳出
            if (mp == 0) return;

            // 使用迴圈重複執行，判斷玩家有沒有按全部技能資料裡面的某一筆
            for (int i = 0; i < dataSkills.Length; i++)
            {
                // 如果魔力 小於 技能的消耗 就跳出
                if (mp < dataSkills[i].skillCost) return;

                // 玩家是否按下技能的按鍵
                if (Input.GetKeyDown(dataSkills[i].skillKey))
                {
                    // 觸發動畫
                    ani.SetTrigger(dataSkills[i].skillParameter);
                    // Quaternion.identity 零角度
                    // 生成物件(要生成的物件，生成後的座標，生成後的角度)
                    // 生成技能特效在玩家的位置上並且角度為零 並存放在 tempSkill 內
                    GameObject tempSkill = Instantiate(dataSkills[i].skillEffect, 
                        transform.position, Quaternion.identity);

                    // 獲得技能的飛行系統並給予玩家的座標
                    tempSkill.GetComponent<FlySystem>().transformPlayer = transform;

                    mp -= dataSkills[i].skillCost;
                    UpdateUI();
                }
            }
        }
    }
}
