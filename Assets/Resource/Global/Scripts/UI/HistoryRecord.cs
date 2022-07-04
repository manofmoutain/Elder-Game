using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Global.UI
{
    public class HistoryRecord : MonoBehaviour
    {
        [SerializeField, Required] private TextMeshProUGUI title;
        [SerializeField, Required] private TextMeshProUGUI correctScore;
        [SerializeField, Required] private List<TextMeshProUGUI> correctTimes;
        [SerializeField, Required] private TextMeshProUGUI wrongScore;
        [SerializeField, Required] private List<TextMeshProUGUI> wrongTimes;

        public void Set(string index)
        {
            title.text = PlayerPrefs.GetString(index);

            correctScore.text = PlayerPrefs.GetString($"{index}-正確分數");

            for (int i = 0; i < 2; i++)
            {
                correctTimes[i].text = PlayerPrefs.GetString($"{index}-正確反應{i}");
            }
            wrongScore.text =  PlayerPrefs.GetString($"{index}-錯誤分數");
            for (int i = 0; i < 2; i++)
            {
                wrongTimes[i].text = PlayerPrefs.GetString($"{index}-錯誤反應{i}");
            }
        }

        public void Clear()
        {
            title.text = string.Empty;
            correctScore.text = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                correctTimes[i].text = string.Empty;
            }
            wrongScore.text =  string.Empty;
            for (int i = 0; i < 2; i++)
            {
                wrongTimes[i].text = string.Empty;
            }
        }


    }
}

