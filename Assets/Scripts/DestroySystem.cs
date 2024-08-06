using UnityEngine;

namespace KID
{
    /// <summary>
    /// 刪除系統
    /// </summary>
    public class DestroySystem : MonoBehaviour
    {
        [SerializeField, Header("刪除時間"), Range(0, 10)]
        private float destroyTime = 1;

        private void Awake()
        {
            Destroy(gameObject, destroyTime);
        }
    }
}
