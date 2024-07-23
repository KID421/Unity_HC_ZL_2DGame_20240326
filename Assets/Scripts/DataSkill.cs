using UnityEngine;

namespace KID
{
    /// <summary>
    /// 技能資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Skill")]
    public class DataSkill : ScriptableObject
    {
        [Header("技能按鍵")]
        public KeyCode skillKey;
        [Header("技能動畫參數")]
        public string skillParameter;
        [Header("技能耗能"), Range(0, 100)]
        public float skillCost;
        [Header("技能傷害"), Range(0, 1000)]
        public float skillDamage;
        [Header("技能特效")]
        public GameObject skillEffect;
    }
}
