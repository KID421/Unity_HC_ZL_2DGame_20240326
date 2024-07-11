using System.Collections;
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
        private bool canAttack = true;

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

        private Attack attack;

        private void Attack()
        {
            // 如果不能攻擊 就跳出
            if (!canAttack) return;
            // 如果玩家按下左鍵，就增加攻擊編號
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // 如果攻擊資料不是空的 就關閉是否繪製
                if (attack != null) attack.isDraw = false;

                attackIndex++;

                // 如果 攻擊編號 == 攻擊資料的數量 就將編號歸零
                if (attackIndex == dataAttack.attacks.Length) attackIndex = 0;
                // 攻擊 = 攻擊資料.攻擊陣列[攻擊編號]
                attack = dataAttack.attacks[attackIndex];
                // 觸發目前攻擊的動畫參數
                ani.SetTrigger(attack.parAttack);

                // 關閉所有協同程序
                StopAllCoroutines();
                StartCoroutine(BreakAttack(attack.attackAnimationTime, attackIndex == dataAttack.attacks.Length - 1));
                StartCoroutine(AttackCheck(attack.attackBeforeTime, attack.attackTime));
            }
        }

        /// <summary>
        /// 中斷攻擊
        /// </summary>
        /// <param name="attackTime">攻擊動畫時間</param>
        /// <param name="finalAttack">是否為最後一個動畫</param>
        private IEnumerator BreakAttack(float attackTime, bool finalAttack)
        {
            // print($"<color=#3f3>是否為最後一個攻擊：{finalAttack}</color>");

            // 如果是最後一個攻擊 就設定為不能攻擊狀態
            if (finalAttack) canAttack = false;

            yield return new WaitForSeconds(attackTime);
            attackIndex = -1;
            // print($"<color=#f33>攻擊編號：{attackIndex}</color>");

            if (finalAttack) canAttack = true;
        }

        private IEnumerator AttackCheck(float attackBefore, float attackTime)
        {
            yield return new WaitForSeconds(attackBefore);
            attack.isDraw = true;
            yield return new WaitForSeconds(attackTime);
            attack.isDraw = false;
        }
    }
}
