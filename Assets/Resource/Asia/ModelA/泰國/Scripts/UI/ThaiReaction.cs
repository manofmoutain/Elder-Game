using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Asia.UI.ModelA;
using UnityEngine;

namespace Asia.Thai.UI
{
    public class ThaiReaction : Reaction
    {
        protected override void AddClick()
        {
            base.AddClick();
            for (int i = 0; i < manager.Data.CurrentDatabases.TargetDatas.Count; i++)
            {
                isClicks.Add(false);
            }
        }
    }
}

