using UnityEngine;

namespace Lian
{
    /// <summary>
    /// NPC ���
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        // �ǦC�����G�N�p�H�ܼ���ܦb Unity �ݩʭ��O
        [SerializeField, Header("NPC ���")]
        private DataNPC dataNPC;

        // Unity ���ʵe����t��
        private Animator ani;

        // ����ƥ� ����C���ɷ|����@��
        private void Awake()
        {
            // ��o NPC ���W���ʵe���
            ani = GetComponent<Animator>();
        }
    }
}