using UnityEngine;

namespace KID
{
    /// <summary>
    /// 攻擊系統
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("攻擊資料")]
        private DataAttack dataAttack;

        private Animator ani;

        private void OnDrawGizmos()
        {
            
        }

        private void Awake()
        {
            ani = GetComponent<Animator>();

            // 迴圈 for：重複執行相同程式
            // for + Table 兩下
            for (int i = 1; i < 11; i++)
            {
                print(i);
            }
        }
    }
}
