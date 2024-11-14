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
        private string url = "https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        private string key = "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";

        private TMP_InputField inputField;
        private string prompt;
        private string role = "你是一個神祕的巫師";

        private void Awake()
        {
            inputField = GameObject.Find("InputField_llm").GetComponent<TMP_InputField>();
            inputField.onEndEdit.AddListener(PlayerInput);
        }

        private void PlayerInput(string input)
        {
            print($"<color=#3f3>{input}</color>");
            prompt = input;
            StartCoroutine(GetResult());
        }

        private IEnumerator GetResult()
        {
            var input = new
            {
                source_sentence = prompt,
	            sentences = ""
            };

            string json = JsonUtility.ToJson(input);
            byte[] postData = Encoding.UTF8.GetBytes(json);

            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + key);

            yield return request.SendWebRequest();

            print(request.result);
        }
    };
}
