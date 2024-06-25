using UnityEngine;

namespace KID
{
    /// <summary>
    /// 血量系統
    /// </summary>
    public class HpSystem : MonoBehaviour
    {
        [SerializeField, Header("血量資料")]
        private DataHp dataHp;

        private float hp, hpMax;

        private void Awake()
        {
            // 將資料內的血量儲存到變數 hp 內
            hp = dataHp.hp;
            hpMax = hp;
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害</param>
        public void Damage(float damage)
        {
            hp -= damage;
            if (hp <= 0) Dead();
            print($"<color=#f36>{name} 血量剩下：{hp}</color>");
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            print($"<color=#f36>{name} 死亡</color>");
        }
    }
}
