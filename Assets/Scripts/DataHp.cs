﻿using UnityEngine;

namespace KID
{
    /// <summary>
    /// 血量資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Hp")]
    public class DataHp : ScriptableObject
    {
        [Header("血量"), Range(0, 100000)]
        public float hp;
    }
}
