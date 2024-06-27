using System.Collections;
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

        // protected 保護：允許此類別與子類別存取
        protected float hp, hpMax;
        private bool isInvicible;

        private void Awake()
        {
            // 將資料內的血量儲存到變數 hp 內
            hp = dataHp.hp;
            hpMax = hp;
        }

        // virtual 虛擬：允許子類別覆寫
        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害</param>
        public virtual void Damage(float damage)
        {
            // 如果 無敵狀態 就跳出
            if (isInvicible) return;

            StartCoroutine(Invicible());
            hp -= damage;
            if (hp <= 0) Dead();
            print($"<color=#f36>{name} 血量剩下：{hp}</color>");
        }

        private IEnumerator Invicible()
        {
            // 進入無敵狀態
            isInvicible = true;
            // 等待無敵時間
            yield return new WaitForSeconds(dataHp.invincibleTime);
            // 恢復沒有無敵狀態
            isInvicible = false;
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
