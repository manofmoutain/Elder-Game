using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using Global.Score;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Asia.UI.ModelC
{
    public class ModelCReaction : ImageController
    {
        [TitleGroup("反應頁"),BoxGroup("反應頁/管理"),SerializeField, Required , HideLabel] protected ModelCManager manager;
        [BoxGroup("反應頁/圖片"),SerializeField, Required , HideLabel] protected Image location;
        [BoxGroup("反應頁/錯誤框"),SerializeField, Required , HideLabel] protected ErrorBorder error;
        [BoxGroup("反應頁/按鈕"),SerializeField, Required , HideLabel] protected Button maru;
        [BoxGroup("反應頁/按鈕"),SerializeField, Required , HideLabel] protected Button cross;

        [TitleGroup("紀錄"),BoxGroup("紀錄/倒數"), SerializeField, DisableInEditorMode , HideLabel]
        protected bool isCounting;

        [BoxGroup("紀錄/計時器"), SerializeField, DisableInEditorMode , HideLabel]
        protected float timer;

        [BoxGroup("紀錄/正確分數"), SerializeField , HideLabel]
        public Score correctScore { get; protected set; }

        [BoxGroup("紀錄/正確的點擊時間"), ShowInInspector, DisableInEditorMode , HideLabel]
        public List<float> correctTime { get; protected set; }

        [BoxGroup("紀錄/錯誤分數") , HideLabel]
        public Score wrongScore { get; protected set; }

        [BoxGroup("紀錄/錯誤的點擊時間"), ShowInInspector, DisableInEditorMode , HideLabel]
        public List<float> wrongTime { get; protected set; }


        private void OnEnable()
        {
            timer = 0;
            correctScore = new Score();
            correctTime = new List<float>();
            wrongScore = new Score();
            wrongTime = new List<float>();
            error.gameObject.SetActive(false);
            isCounting = true;
            if (manager.CurrentDataTargetCount != 0)
            {
                location.sprite = manager.currentData.TargetDatas[0].sprite;
            }
            else if (manager.currentData.items.Count != 0)
            {
                location.sprite = manager.currentData.items[0].sprite;
            }
        }

        private void Start()
        {
            maru.onClick.AddListener(delegate { HasAppeared(); });

            cross.onClick.AddListener(delegate { HasntAppeared(); });
        }

        private void Update()
        {
            if (isCounting)
            {
                timer += Time.deltaTime;
            }
        }

        protected virtual void HasntAppeared()
        {
            if (!manager.DicHasValue(location.sprite.name))
            {
                isCounting = false;
                manager.CurrentRecord.SetCorrectScore("1");
                manager.CurrentRecord.AddCorrectTime(timer.ToString("0.00"));
                manager.AddDicValue(location.sprite.name);
                manager.CorrectAnswer();
                SetNextActive(true);
                manager.SetCurrentData();
            }
            else
            {
                isCounting = false;
                manager.CurrentRecord.SetWrongScore("1");
                manager.CurrentRecord.AddWrongTime(timer.ToString("0.00"));
                manager.AddDicValue(location.sprite.name);
                error.gameObject.SetActive(true);
                SetNextActive(true);
                manager.SetCurrentData();
            }
        }

        protected virtual void HasAppeared()
        {
            if (manager.DicHasValue(location.sprite.name))
            {
                isCounting = false;
                manager.CurrentRecord.SetCorrectScore("1");
                manager.CurrentRecord.AddCorrectTime(timer.ToString("0.00"));
                manager.CorrectAnswer();
                SetNextActive(true);
                manager.SetCurrentData();
            }
            else
            {
                isCounting = false;
                manager.CurrentRecord.SetWrongScore("1");
                manager.CurrentRecord.AddWrongTime(timer.ToString("0.00"));
                manager.AddDicValue(location.sprite.name);
                error.gameObject.SetActive(true);
                SetNextActive(true);
                manager.SetCurrentData();
            }
        }


        public void SetLocation(Sprite newSprite)
        {
            location.sprite = newSprite;
        }
    }
}