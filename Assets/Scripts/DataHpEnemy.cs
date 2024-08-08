using UnityEngine;

namespace KID
{
    /// <summary>
    /// 血量資料：敵人
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Hp Enemy")]
    public class DataHpEnemy : DataHp
    {
        [Header("掉落物件資料")]
        public DropObject[] dropObjects;
        [Header("掉落物件噴射力道")]
        [Range(0, 500)]
        public float upMin;
        [Range(0, 500)]
        public float upMax;
        [Range(-500, 500)]
        public float horizontalMin;
        [Range(0, 500)]
        public float horizontalMax;
    }

    // 類別預設不會顯示(不會序列化)
    // System.Serializable 類別專用序列化
    [System.Serializable]
    public class DropObject
    {
        public GameObject prefab;
        [Range(0, 1)]
        public float probability;
        [Range(0, 10)]
        public float offsetY;
    }
}
