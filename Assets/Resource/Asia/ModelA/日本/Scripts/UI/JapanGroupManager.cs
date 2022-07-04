using System.Collections;
using System.Collections.Generic;
using Asia.JaPan.Database;
using Asia.UI;
using Asia.UI.ModelA;
using Asin.China.Database;
using Global.Score;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.JaPan.UI
{
    public class JapanGroupManager : GroupManager
    {
        public bool CheckItems(Sprite _sprite)
        {
            switch (data.CurrentDatabases.TargetDatas.Count)
            {
                case 1:
                {
                    if (_sprite == data.CurrentDatabases.TargetDatas[0].sprite) CheckItem1 = true;
                    return _sprite == data.CurrentDatabases.TargetDatas[0].sprite;
                }
                case 2:
                {
                    if (_sprite == data.CurrentDatabases.TargetDatas[0].sprite) CheckItem1 = true;
                    if (_sprite == data.CurrentDatabases.TargetDatas[1].sprite) CheckItem2 = true;
                    return _sprite == data.CurrentDatabases.TargetDatas[0].sprite || _sprite == data.CurrentDatabases.TargetDatas[1].sprite;
                }
                default:
                    return false;
            }
        }


    }
}

