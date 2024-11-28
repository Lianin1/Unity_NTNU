using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Lian
{
    ///<summary>
    ///�ҫ��޲z��
    ///</summary>
    public class HuggingFaceManager : MonoBehaviour
    {
        private string url = "https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        private string key = "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";

        private TMP_InputField inputField;
        private string prompt;
        private string role = "�A�O�@��Ův";
        private string[] npcSentences;

        [SerializeField, Header("NPC ����")]
        private NPCController npc;

        private void Awake()
        {
            inputField = GameObject.Find("InputField_llm").GetComponent<TMP_InputField>();
            inputField.onEndEdit.AddListener(PlayerInput);
            npcSentences = npc.data.sentences;
        }

        private void PlayerInput(string input)
        {
            print($"<color=#3f3>���a��J�G{input}</color>");
            prompt = input;
            StartCoroutine(GetResult());
        }

        private IEnumerator GetResult()
        {
            var inputs = new
            {
                source_sentence = prompt,
                sentences = npcSentences
            };

            string json = JsonConvert.SerializeObject(inputs);
            byte[] postData = Encoding.UTF8.GetBytes(json);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + key);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                print($"<color=#f33>�n�D���ѡG{request.error}</color>");
            }
            else
            {
                string reponseText = request.downloadHandler.text;
                var reponse = JsonConvert.DeserializeObject<List<float>>(reponseText);

                print($"<color=#3f3>���ơG{reponseText}</color>");

                if (reponse != null && reponse.Count > 0)
                {
                    int best = reponse.Select((value, index) => new
                    {
                        value = value,
                        index = index
                    }).OrderByDescending(x => x.value).First().index;

                    print($"<color=#77f>�̨ε��G:{npcSentences[best]}</color>");

                    npc.PlayAinmation(best);
                }
            }

        }
    }
}