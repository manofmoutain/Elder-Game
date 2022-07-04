using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using Global.SFX;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Asia.UI
{
    public class ReactionGuid : ImageController
    {
        [SerializeField] private TextMeshProUGUI reactorGuidText;
        [SerializeField, Required] private AudioController audio;

        private void OnEnable()
        {
            audio.PlayOneShot(0);
            SetNextActive(true);
        }

        public void SetText(string newText)
        {
            reactorGuidText.text = newText;
        }

        IEnumerator CoPlaySFX()
        {
            if (fadeInSecond>audio.clipTime(0))
            {
                yield return new WaitForSeconds(audio.clipTime(0));

            }
            yield return new WaitForSeconds(audio.clipTime(0));
            audio.PlayOneShot(0);
            SetNextActive(true);
        }
    }
}

