using UnityEngine;

namespace Lian
{
    /// <summary>
    /// NPC ���
    /// </summary>
    [CreateAssetMenu(menuName = "Lian/NPC")]
    public class DataNPC : ScriptableObject

    {
        [Header("NPC �n���R���y�l")]
        public string[] sentences;
    }
}