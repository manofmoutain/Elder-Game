using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Score
{
    [Serializable]
    public class Score
    {
        [BoxGroup("總分"),ShowInInspector] public int totalScore { get; private set; }


        public void AddScore(int score)
        {
            totalScore += score;
        }

    }
}

