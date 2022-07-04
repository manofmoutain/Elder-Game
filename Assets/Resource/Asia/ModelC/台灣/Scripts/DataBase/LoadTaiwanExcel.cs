#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Global.Database;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.Taiwan.Database
{
    public class LoadTaiwanExcel : RefreshByExcel
    {
        [TitleGroup("資料庫")] [SerializeField, Required]
        protected List<ModelCTaiwanDatabase> database;


        protected override void LoadTarget()
        {
            base.LoadTarget();
            for (int i = 0; i < database.Count; i++)
            {
                string _name = LoadText(targetRow+i,targetColumn);
                for (int j = 0; j < targetSprites.Count; j++)
                {
                    if (targetSprites[j].name ==_name)
                    {
                        TargetData newTarget = new TargetData();
                        newTarget.Set(targetSprites[j],0);
                        database[i].TargetDatas.Add(newTarget);
                        break;
                    }
                }
            }
        }

        protected override void LoadItems()
        {
            base.LoadItems();
            for (int i = 0; i < database.Count; i++)
            {
                string _name = LoadText(itemRow+i,itemLocationColumn);
                for (int j = 0; j < itemSprites.Count; j++)
                {
                    if (itemSprites[j].name ==_name)
                    {
                        ItemData newItem = new ItemData();
                        newItem.Set(itemSprites[j] , 0);
                        database[i].items.Add(newItem);
                        break;
                    }
                }
            }
        }
    }
}
#endif

