using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Score
{
    [Serializable]
    public class Record
    {
        [BoxGroup("題號")]
        public string dataBaseIndex;

        [BoxGroup("正確分數")]
        public string correctScore;

        [BoxGroup("正確反應時間")]
        public List<string> correctTime;

        [BoxGroup("錯誤分數")]
        public string wrongScore;

        [BoxGroup("錯誤反應時間")]
        public List<string> wrongTime;

        public Record()
        {
            correctTime = new List<string>();
            wrongTime = new List<string>();
        }

        public void SetIndex(string _index)
        {
            dataBaseIndex = _index;
        }

        public void SetCorrectScore(string _score)
        {
            correctScore = _score;
        }

        public void SetWrongScore(string _score)
        {
            wrongScore = _score;
        }


        public void AddCorrectTime(string _time)
        {
            correctTime.Add(_time);
        }

        public void AddWrongTime(string _time)
        {
            wrongTime.Add(_time);
        }
    }
}

