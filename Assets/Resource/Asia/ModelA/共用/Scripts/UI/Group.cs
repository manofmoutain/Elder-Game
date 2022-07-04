using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asia.UI.ModelA
{
    public class Group : ImageController
    {
        [BoxGroup("第1頁"), Required, HideLabel, SerializeField]
        public Stimulate Stimulate;

        [BoxGroup("第2頁"), Required, HideLabel, SerializeField]
        public ReactionGuid ReactionGuid;

        [BoxGroup("第3頁"), Required, HideLabel, SerializeField]
        public Reaction Reaction;

        [BoxGroup("第4頁"), Required, HideLabel, SerializeField]
        public FeedBackBlank FeedBackBlank;

        [BoxGroup("第5頁"), Required, HideLabel, SerializeField]
        public FeedBackPage feedBackPage;


        private void OnEnable()
        {
            Stimulate.SetActive(false);
            ReactionGuid.SetActive(false);
            Reaction.SetActive(false);
            FeedBackBlank.SetActive(false);
            feedBackPage.SetActive(false);
        }
    }
}