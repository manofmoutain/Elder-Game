using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.China.UI
{
    public class ChinaStartPage : StartPage
    {
        [SerializeField, Required] private ChinaGroupManager manager;

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