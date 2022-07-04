using System.Collections;
using System.Collections.Generic;
using Asia.Thai.Database;
using Asia.UI;
using Asia.UI.ModelA;
using Global.Score;
using UnityEngine;

namespace Asia.Thai.UI
{
    public class ThaiGroupManager : GroupManager
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
                case 3 :
                    if (_sprite == data.CurrentDatabases.TargetDatas[0].sprite) CheckItem1 = true;
                    if (_sprite == data.CurrentDatabases.TargetDatas[1].sprite) CheckItem2 = true;
                    if (_sprite == data.CurrentDatabases.TargetDatas[1].sprite) CheckItem3 = true;
                    return _sprite == data.CurrentDatabases.TargetDatas[0].sprite || _sprite == data.CurrentDatabases.TargetDatas[1].sprite || _sprite == data.CurrentDatabases.TargetDatas[2].sprite;
                    break;
                default:
                    return false;
            }
        }


    }
}