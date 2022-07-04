using System.Collections;
using System.Collections.Generic;
using Asia.UI.ModelC;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.Taiwan.UI
{
    public class TaiwanSample : ModelCSample
    {
        [SerializeField,Required] private TaiwanDataManager manager;


        public override void SetNextActive(bool boolean)
        {
            base.SetNextActive(boolean);
            manager.SetCurrentData();

        }
    }
}

