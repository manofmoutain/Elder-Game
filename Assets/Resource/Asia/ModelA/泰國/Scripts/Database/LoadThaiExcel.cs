#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Global.Database;
using UnityEngine;

namespace Asia.Thai.Database
{
    public class LoadThaiExcel : RefreshByExcel
    {
        [SerializeField] private List<ModelAThaiDatabase> database;
         protected override void LoadTarget()
        {
            base.LoadTarget();

            for (int i = 0; i < database.Count; i++)
            {
                database[i].TargetDatas = new List<TargetData>();
                List<string> _target = new List<string>();
                _target = LoadTargetTexts(i);

                for (int j = 0; j < targetSprites.Count; j++)
                {
                    for (int k = 0; k < targetLocationCount; k++)
                    {
                        for (int l = 0; l < targetCount; l++)
                        {
                            for (int m = 0; m < (int)database[i].Difficulties + 1; m++)
                            {
                                if (targetSprites[j].name == _target[l] && targetSprites[j].name == _target[k + targetCount])
                                {
                                    TargetData newTarget = new TargetData();
                                    newTarget.Set(targetSprites[j], (Location)k);
                                    database[i].TargetDatas.Add(newTarget);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void LoadItems()
        {
            base.LoadItems();
            for (int i = 0; i < database.Count; i++)
            {
                database[i].items = new List<ItemData>();
                List<string> _locationNames = new List<string>();
                _locationNames = LoadLocationTexts(i);
                for (int j = 0; j < itemSprites.Count; j++)
                {
                    for (int k = 0; k < itemLocationCount; k++)
                    {
                        if (itemSprites[j].name == _locationNames[k])
                        {
                            ItemData newData = new ItemData();
                            newData.Set(itemSprites[j],(Location)k);
                            database[i].items.Add(newData);
                        }
                    }
                }
            }
        }

        protected override void LoadFeedBack()
        {
            base.LoadFeedBack();
            for (int i = 0; i < database.Count; i++)
            {
                string spritName = LoadText(i + feedBackRow, feedBackSpriteColumn);
                string _text = LoadText(i + feedBackRow, feedBackTextColumn);
                int _point = LoadInt(i + feedBackRow, feedBackPointColum);
                for (int j = 0; j < feedBackSprite.Count; j++)
                {
                    for (int k = 0; k < feedBackSFX.Count; k++)
                    {
                        if (feedBackSprite[j].name == spritName && _text ==feedBackSFX[k].name)
                        {
                            database[i].feedback.Set(feedBackSprite[j], _text, _point, feedBackSFX[k]);
                        }
                    }
                }
            }
        }
    }
}
#endif
