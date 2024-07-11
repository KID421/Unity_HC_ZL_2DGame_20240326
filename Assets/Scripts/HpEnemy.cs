using UnityEngine;

namespace KID
{
    /// <summary>
    /// 血量系統：敵人
    /// </summary>
    public class HpEnemy : HpSystem
    {
        protected override void Dead()
        {
            base.Dead();
            Destroy(gameObject, 1.3f);
        }
    }
}
