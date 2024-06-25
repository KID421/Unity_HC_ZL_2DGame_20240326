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
    }
}
