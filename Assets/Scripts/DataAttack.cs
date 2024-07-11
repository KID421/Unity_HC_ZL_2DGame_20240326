using UnityEngine;

namespace KID
{
    /// <summary>
    /// 攻擊資料：玩家
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Player Attack")]
    public class DataAttack : ScriptableObject
    {
        // [] 陣列：儲存多筆相同類型的資料
        // int[] float[] bool[] string[]
        public Attack[] attacks;
    }

    // 自訂類別：儲存攻擊資料
    // [System.Serializable] 將類別資料序列化顯示在面板
    [System.Serializable]
    public class Attack
    {
        [Header("攻擊動畫參數")]
        public string parAttack;
        [Header("攻擊力"), Range(0, 2000)]
        public float attack;
        [Header("攻擊力浮動百分比"), Range(0, 1)]
        public float attackFloatValue;
        [Header("攻擊前搖時間"), Range(0, 2f)]
        public float attackBeforeTime = 0.6f;
        [Header("攻擊時間"), Range(0, 1f)]
        public float attackTime = 0.3f;
        [Header("攻擊區域尺寸")]
        public Vector3 attackAreaSize = Vector3.one;
        [Header("攻擊區域位移")]
        public Vector3 attackAreaOffset;
        [Header("是否繪製")]
        public bool isDraw;
        [Header("攻擊動畫時間：連段時間"), Range(0, 2)]
        public float attackAnimationTime;
    }
}
