using UnityEngine;

namespace KID
{
    /// <summary>
    /// 影子跟隨系統：跟隨指定物件
    /// </summary>
    public class ShadowFollow : MonoBehaviour
    {
        [Header("要跟隨的物件")]
        public Transform followTarget;
        [SerializeField, Header("影子的 Y 軸")]
        private float shadowY;

        private void Update()
        {
            Follow();
        }

        /// <summary>
        /// 跟隨
        /// </summary>
        private void Follow()
        {
            // 座標 = 獲得跟隨物件的座標
            Vector3 point = followTarget.position;
            // 設定座標的 Y 軸 等於 影子的 Y 軸
            point.y = shadowY;
            // 此物件的座標 指定成 座標
            transform.position = point;
        }
    }
}
