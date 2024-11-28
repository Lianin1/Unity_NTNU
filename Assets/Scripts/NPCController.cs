using System;
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
        [SerializeField, Header("�ʵe�Ѽ�")]
        private string[] parameters =
        {
            "���� 1", "���� 2", "���� 3", "���`"
        };

        // Unity ���ʵe����t��
        private Animator ani;

        public DataNPC data => dataNPC;

        // ����ƥ� ����C���ɷ|����@��
        private void Awake()
        {
            // ��o NPC ���W���ʵe���
            ani = GetComponent<Animator>();
        }

        public void PlayAinmation (int Index)
        {
            ani.SetTrigger(parameters[Index]);
        }
    }
}