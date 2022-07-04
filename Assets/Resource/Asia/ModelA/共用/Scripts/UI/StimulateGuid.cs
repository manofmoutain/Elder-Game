using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using TMPro;
using UnityEngine;

namespace Asia.UI
{
    public class StimulateGuid : ImageController
    {
        [SerializeField] private TextMeshProUGUI stimulatedGuidText;


        private void OnEnable()
        {
            SetNextActive(true);
        }

        public void SetStimulateGuidText(string newText)
        {
            stimulatedGuidText.text = newText;
        }
    }
}

