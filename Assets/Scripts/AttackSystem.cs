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
        private int attackIndex = -1;

        private void OnDrawGizmos()
        {
            // 迴圈執行全部的攻擊資料
            // 抓到陣列的數量：陣列.Length
            for (int i = 0; i < dataAttack.attacks.Length; i++)
            {
                // 抓到每一筆攻擊資料
                Attack attack = dataAttack.attacks[i];
                // 如果攻擊資料要繪製才會執行
                if (attack.isDraw)
                {
                    Gizmos.color = new Color(1, 0.3f, 0.3f, 0.6f);
                    Gizmos.DrawCube(
                        transform.position + transform.TransformDirection(attack.attackAreaOffset),
                        attack.attackAreaSize);
                }
            }
        }

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            // 如果玩家按下左鍵，就增加攻擊編號
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attackIndex++;
                print($"<color=#f33>攻擊編號：{attackIndex}</color>");
            }
        }
    }
}
