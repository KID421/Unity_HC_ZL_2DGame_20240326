using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("移動速度：X 軸"), Range(0, 10)]
        public float moveSpeedXAxis = 1.5f;
        [Header("移動速度：Z 軸"), Range(0, 5)]
        public float moveSpeedZAxis = 1.2f;
        [Header("X 軸停止距離"), Range(0, 5)]
        public float stopDistanceX = 1.3f;
        [Header("Z 軸停止距離"), Range(0, 1.5f)]
        public float stopDistanceZ = 0.8f;
        [Header("攻擊停止距離 X"), Range(0, 3f)]
        public float attackStopDistanceX = 2.5f;
        [Header("攻擊停止距離 Z"), Range(0, 3f)]
        public float attackStopDistanceZ = 0.5f;
        [Header("攻擊前搖時間"), Range(0, 2f)]
        public float attackBeforeTime = 0.6f;
        [Header("攻擊時間"), Range(0, 1f)]
        public float attackTime = 0.3f;
        [Header("攻擊後搖時間"), Range(0, 5f)]
        public float attackAfterTime = 2f;
        [Header("攻擊區域尺寸")]
        public Vector3 attackAreaSize = Vector3.one;
        [Header("攻擊區域位移")]
        public Vector3 attackAreaOffset;
        [Header("攻擊力"), Range(0, 10000)]
        public float attack;
        [Header("攻擊力浮動百分比"), Range(0, 1)]
        public float attackFloatValue;
    }
}
