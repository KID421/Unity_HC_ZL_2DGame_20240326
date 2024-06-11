using UnityEngine;

namespace KID
{
    /// <summary>
    /// 影子：敵人
    /// </summary>
    public class ShadowEnemy : MonoBehaviour
    {
        [SerializeField, Header("影子預製物")]
        private GameObject prefabShadow;

        private void Awake()
        {
            // 生成一個影子跟隨物件並獲得他的 ShadowFollow 腳本
            // 影子跟隨 = 生成(要生成的物件) 的 取得元件<影子跟隨>()
            ShadowFollow shdowFollow = Instantiate(prefabShadow).GetComponent<ShadowFollow>();
            // 指定影子跟隨 的 目標 為 此物件
            shdowFollow.followTarget = transform;
        }
    }
}

