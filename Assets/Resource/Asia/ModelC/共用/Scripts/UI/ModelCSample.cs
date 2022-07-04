using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using Global.SFX;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Asia.UI.ModelC
{
    public class ModelCSample : ImageController
    {
        [SerializeField, Required] protected Button startButton;
        [SerializeField, Required] protected AudioController sfx;
        [SerializeField, Required] protected Image picture;

        private void OnEnable()
        {
            // sfx.PlayOneShot(0);
        }

        private void Start()
        {
            startButton.onClick.AddListener(delegate { SetNextActive(true); }
            );
        }

        public void SetPicture(Sprite newSprite)
        {
            picture.sprite = newSprite;
        }
    }
}