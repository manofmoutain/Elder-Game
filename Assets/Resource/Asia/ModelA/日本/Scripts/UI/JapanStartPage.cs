using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.JaPan.UI
{
    public class JapanStartPage : StartPage
    {
        [SerializeField, Required] private JapanGroupManager manager;

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

