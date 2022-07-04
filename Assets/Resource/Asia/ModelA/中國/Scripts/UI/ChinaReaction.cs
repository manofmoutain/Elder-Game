using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Asia.UI.ModelA;
using UnityEngine;

namespace Asia.China.UI
{
    public class ChinaReaction : Reaction
    {
        protected override void AddClick()
        {
            base.AddClick();
            for (int i = 0; i < manager.Data.CurrentDatabases.items.Count; i++)
            {
                isClicks.Add(false);
            }
        }
    }
}

