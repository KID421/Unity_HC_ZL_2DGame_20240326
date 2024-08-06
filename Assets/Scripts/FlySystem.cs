using UnityEngine;

namespace KID
{
    /// <summary>
    /// 飛行系統
    /// </summary>
    public class FlySystem : MonoBehaviour
    {
        public Transform transformPlayer;

        [SerializeField, Header("飛行力道")]
        private Vector3 flyPower;

        private Rigidbody rig;

        private void Start()
        {
            rig = GetComponent<Rigidbody>();
            // 根據玩家的座標飛行
            rig.AddForce(
                transformPlayer.right * flyPower.x + 
                transformPlayer.up * flyPower.y + 
                transformPlayer.forward * flyPower.z);
        }
    }
}
