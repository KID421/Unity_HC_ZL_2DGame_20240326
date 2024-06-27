using System.Collections;
using TMPro;
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
        [SerializeField, Header("預製物：畫布傷害值")]
        private GameObject prefabDamage;
        [SerializeField, Header("傷害值位移")]
        private float damageOffset = 1;

        // protected 保護：允許此類別與子類別存取
        protected float hp, hpMax;
        private bool isInvicible;
        private Animator ani;
        private string parDead = "觸發死亡";

        private void Awake()
        {
            // 將資料內的血量儲存到變數 hp 內
            hp = dataHp.hp;
            hpMax = hp;
            ani = GetComponent<Animator>();
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

            // 暫存傷害值 = 生成(物件，座標，角度)
            GameObject tempDamage = Instantiate(prefabDamage, 
                transform.position + Vector3.up * damageOffset, Quaternion.identity);
            // 暫存傷害值 取得子物件 "文字傷害值" 更新文字
            tempDamage.transform.Find("文字傷害值").GetComponent<TMP_Text>().text = damage.ToString();
            // 刪除(暫存傷害值，延遲時間)
            Destroy(tempDamage, 1);

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
            ani.SetTrigger(parDead);
            print($"<color=#f36>{name} 死亡</color>");
        }
    }
}
