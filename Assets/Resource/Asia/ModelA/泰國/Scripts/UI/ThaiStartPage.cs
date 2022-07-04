using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.Thai.UI
{
    public class ThaiStartPage : StartPage
    {
        [SerializeField, Required] private ThaiGroupManager manager;

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

