using System;
using System.Collections;
using System.Collections.Generic;
using Global.Database;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Database
{
    [Serializable]
    public class TargetData
    {
        [ShowInInspector]
        [HorizontalGroup("Split", Width = 70), BoxGroup("Split/圖片"), HideLabel]
        [PreviewField(Height = 50, Alignment = ObjectFieldAlignment.Left)]
        public Sprite sprite;

        [ShowInInspector] [BoxGroup("Split/位置")] [EnumToggleButtons, HideLabel]
        public Location location;

        public void Set(Sprite newSprite , Location newLocation)
        {
            sprite = newSprite;
            location = newLocation;
        }
    }
}

