using UnityEngine;

namespace KID
{
    /// <summary>
    /// �v�l���H�t�ΡG���H���w����
    /// </summary>
    public class ShadowFollow : MonoBehaviour
    {
        [SerializeField, Header("�n���H������")]
        private Transform followTarget;
        [SerializeField, Header("�v�l�� Y �b")]
        private float shadowY;

        private void Update()
        {
            Follow();
        }

        /// <summary>
        /// ���H
        /// </summary>
        private void Follow()
        {
            // �y�� = ��o���H���󪺮y��
            Vector3 point = followTarget.position;
            // �]�w�y�Ъ� Y �b ���� �v�l�� Y �b
            point.y = shadowY;
            // �����󪺮y�� ���w�� �y��
            transform.position = point;
        }
    }
}
