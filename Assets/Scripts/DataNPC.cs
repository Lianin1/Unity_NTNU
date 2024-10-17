using UnityEngine;

namespace Lian
{
    /// <summary>
    /// NPC 資料
    /// </summary>
    [CreateAssetMenu(menuName = "Lian/NPC")]
    public class DataNPC : ScriptableObject

    {
        [Header("NPC 要分析的句子")]
        public string[] sentences;
    }
}