using System.Collections;
using System.Collections.Generic;
using Asia;
using Asia.China;
using Asia.China.UI;
using Asia.UI.ModelA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Asin.China.UI
{
    public class ChinaItem : Item
    {
        [SerializeField, Required] private ChinaGroupManager groupManager;


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
                if (groupManager.CheckItem1 && groupManager.CheckItem2)
                {
                    groupManager.ShowFeedBack();
                }
                else
                {
                    groupManager.ShowWrongPage();
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