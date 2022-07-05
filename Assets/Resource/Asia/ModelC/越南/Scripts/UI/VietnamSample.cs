using System.Collections;
using System.Collections.Generic;
using Asia.UI.ModelC;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.Vietnam.UI
{
    public class VietnamSample : ModelCSample
    {
        [SerializeField,Required] private VietnamDataManager manager;


        public override void SetNextActive(bool boolean)
        {
            base.SetNextActive(boolean);
            manager.SetCurrentData();

        }
    }
}

