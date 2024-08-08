using UnityEngine;

namespace KID
{
    /// <summary>
    /// 道具管理器：吃道具以及處理吃道具後的行為
    /// </summary>
    public class PropManager : MonoBehaviour
    {
        private string propName = "道具";
        private string propHp = "道具_血量藥水";
        private string propMp = "道具_魔力藥水";

        // 碰撞事件 OCE
        // 碰到物件後會執行一次
        // collision 會儲存碰到物件的碰撞資訊
        private void OnCollisionEnter(Collision collision)
        {
            // 如果 碰到物件的名稱 有"道具"這兩個字
            if (collision.gameObject.name.Contains(propName))
            {
                EatProp(collision.gameObject.name);
                // 刪除道具物件
                Destroy(collision.gameObject);
            }
        }

        private void EatProp(string prop)
        {

        }
    }
}
