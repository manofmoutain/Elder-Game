using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asia.UI.ModelC
{
    public class ErrorBorder : MonoBehaviour
    {
        private void OnEnable()
        {
            InvokeRepeating(nameof(Blink),0.2f,0.2f);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        void Blink()
        {
            Image image = GetComponent<Image>();
            image.enabled = !image.enabled;
        }
    }
}

