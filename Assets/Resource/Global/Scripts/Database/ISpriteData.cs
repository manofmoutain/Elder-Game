using System.Collections;
using System.Collections.Generic;
using Global.Database;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Database
{
    public interface ISpriteData
    {
        public Sprite sprite { get; set; }
        public Location location { get; set; }
    }
}

