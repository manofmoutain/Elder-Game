using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using Global.SFX;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asia.UI.ModelA
{
    public class FeedBackPage : ImageController
    {
        [SerializeField,Required] private TextMeshProUGUI feedBackText;
        [SerializeField,Required] private Image feedbackImage;
        [SerializeField,Required] private TextMeshProUGUI gotPoint;
        [SerializeField,Required] private AudioController audio;
        [SerializeField, Required] private GroupManager _database;

        private void OnEnable()
        {
            audio = GetComponent<AudioController>();
            StartCoroutine(Reset());
        }

        IEnumerator Reset()
        {
            audio.PlayOneShot(0);
            yield return new WaitForSeconds(fadeInSecond);
            _database.ChangeCurrentDatabase();
            SetActive(false);
        }


        public void SetFeedBackText(string newText)
        {
            feedBackText.text = newText;
        }

        public void SetFeedBackImage(Sprite newSprite)
        {
            feedbackImage.sprite = newSprite;
        }

        public void SetPoint(int point)
        {
            gotPoint.text = $"恭喜！這題您得到 <size=140>{point} </size>點";
        }

        public void SetSFX(AudioClip clip)
        {
            audio.Clear();
            audio.Add(clip);
        }

    }
}

