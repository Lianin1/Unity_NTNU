using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;

namespace Lian
{
    ///<summary>
    ///模型管理器
    ///</summary>
    public class HuggingFaceManager : MonoBehaviour
    {
        private string model = "https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        private string key = "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";

        private TMP_InputField inputFieldPlayer;

        private void Awake()
        {
            inputFieldPlayer = GameObject.Find("InputField_llm").GetComponent<TMP_InputField>();
            inputFieldPlayer.onEndEdit.AddListener(PlayerInput);
        }

        private void PlayerInput(string input)
        {
            print($"<color=#3f3>玩家輸入：{input}</color>");
        }
    }
}