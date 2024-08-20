using UnityEngine;

namespace KID
{
    /// <summary>
    /// 道具：保存道具數值
    /// </summary>
    public class Prop : MonoBehaviour
    {
        [Header("道具數值"), Range(0, 1000)]
        public float value;
    }
}
