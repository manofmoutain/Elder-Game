using System.Collections;
using System.Collections.Generic;
using Asia.UI.ModelA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Asia.Thai.UI
{
    public class ThaiItem : Item
    {
        [SerializeField,Required] private ThaiGroupManager groupManager;


        protected override void Check()
        {
            base.Check();
            isChecked = groupManager.CheckItems(GetComponent<Image>().sprite);
            if (isChecked)
            {
                reaction.AddCorrectScore(1);
                reaction.AddCorrectTime();
            }
            else
            {
                reaction.AddWrongScore(1);
                reaction.AddWrongTime();
            }
            if (reaction.isAllClick)
            {
                switch (groupManager.Data.CurrentDatabases.TargetDatas.Count)
                {
                    case 1:
                        if (groupManager.CheckItem1)
                        {
                            groupManager.ShowFeedBack();
                        }
                        else
                        {
                            groupManager.ShowWrongPage();
                        }
                        break;

                    case 2 :
                        if (groupManager.CheckItem1 && groupManager.CheckItem2)
                        {
                            groupManager.ShowFeedBack();
                        }
                        else
                        {
                            groupManager.ShowWrongPage();
                        }
                        break;
                    case 3 :
                        if (groupManager.CheckItem1 && groupManager.CheckItem2 && groupManager.CheckItem3)
                        {
                            groupManager.ShowFeedBack();
                        }
                        else
                        {
                            groupManager.ShowWrongPage();
                        }
                        break;
                }
                reaction.NewRecord();
            }

        }

        protected override void Cancel()
        {
            base.Cancel();
            groupManager.ResetChecks();
        }
    }
}

