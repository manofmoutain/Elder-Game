using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Asia.UI.ModelA;
using UnityEngine;

namespace Asia.Philippine.UI
{
    public class PhilippineReaction : Reaction
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

