using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.Philippine.UI
{
    public class PhilippineStartPage : StartPage
    {
        [SerializeField, Required] private PhilippineGroupManager manager;

        protected override void Start()
        {
            base.Start();
            button.onClick.AddListener
            (
                delegate
                {
                    manager.ChangeCurrentDatabase();
                    SetActive(false);
                }
            );
        }
    }
}

