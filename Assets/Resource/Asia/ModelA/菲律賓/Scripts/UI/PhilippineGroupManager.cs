using System.Collections;
using System.Collections.Generic;
using Asia.Philippine.Database;
using Asia.UI;
using Asia.UI.ModelA;
using Global.Score;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.Philippine
{
    public class PhilippineGroupManager : GroupManager
    {
        public bool CheckItems(Sprite _sprite)
        {
            if (_sprite == data.CurrentDatabases.items[0].sprite) CheckItem1 = true;
            if (_sprite == data.CurrentDatabases.items[1].sprite) CheckItem2 = true;
            return _sprite == data.CurrentDatabases.items[0].sprite || _sprite == data.CurrentDatabases.items[1].sprite;
        }


    }
}

