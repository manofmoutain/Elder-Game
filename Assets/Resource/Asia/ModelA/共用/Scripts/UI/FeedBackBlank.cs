using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using Global.SFX;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Asia.UI.ModelA
{
    public class FeedBackBlank : ImageController
    {
        [SerializeField, Required] private GroupManager _database;
        [SerializeField, Required] private AudioController audio;
        private void OnEnable()
        {
            audio.PlayOneShot(0);
            StartCoroutine(Reset());
        }

        IEnumerator Reset()
        {
            yield return new WaitForSeconds(fadeInSecond);
            _database.ChangeCurrentDatabase();
            SetActive(false);
        }
    }
}

