using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Database
{
    [Serializable]
    public class FeedBack
    {
        [HorizontalGroup("Split"),BoxGroup("Split/回饋圖"), HideLabel]
        [PreviewField(Height = 50, Alignment = ObjectFieldAlignment.Left)]
        [AssetSelector(Paths = "Assets/Resource/Image/China/回饋圖")]
        public Sprite feedback;

        [VerticalGroup("Split/Split"),BoxGroup("Split/Split/回饋文字"), HideLabel]
        public string feedbackText;

        [BoxGroup("Split/Split/點數"), HideLabel]
        public int feedbackPoint;

        [BoxGroup("Split/Split/回饋語音"), HideLabel]
        public AudioClip feedbackSFX;

        // public FeedBack(Sprite newSprite , string text , int point)
        // {
        //     feedback = newSprite;
        //     feedbackText = text;
        //     feedbackPoint = point;
        // }

        public void Set(Sprite newSprite, string text, int point, AudioClip clip)
        {
            feedback = newSprite;
            feedbackText = text;
            feedbackPoint = point;
            feedbackSFX = clip;
        }
    }
}

