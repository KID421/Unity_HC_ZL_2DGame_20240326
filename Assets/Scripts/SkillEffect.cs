using UnityEngine;

namespace KID
{
    /// <summary>
    /// 技能特效
    /// </summary>
    public class SkillEffect : MonoBehaviour
    {
        [SerializeField, Header("技能資料")]
        private DataSkill dataSkill;

        // 有勾選 IsTrigger 要使用這個事件偵測有沒有碰撞
        private void OnTriggerEnter(Collider other)
        {
            // 如果 碰到的物件名稱 包含 敵人這兩個字
            if (other.name.Contains("敵人"))
            {
                // 就造成傷害
                other.GetComponent<HpEnemy>().Damage(dataSkill.skillDamage);
            }
        }
    }
}
