using System;
using System.Collections;
using System.Collections.Generic;
using Global.Database;
using Global.ImageControl;
using Global.Score;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.UI.ModelA
{
    public class Reaction : ImageController
    {
        [TitleGroup("反應頁"), FoldoutGroup("反應頁/反應頁"), BoxGroup("反應頁/反應頁/管理"), SerializeField, Required]
        protected GroupManager manager;

        [BoxGroup("反應頁/反應頁/錯誤反饋"), SerializeField]
        protected FeedBackBlank wrongNext;

        [BoxGroup("反應頁/反應頁/所有反應")] public List<Item> items;

        [BoxGroup("反應頁/反應頁/點擊"), SerializeField]
        protected List<bool> isClicks;

        [BoxGroup("反應頁/反應頁/倒數"), SerializeField, DisableInEditorMode]
        protected bool isCounting;

        [BoxGroup("反應頁/反應頁/計時器"), SerializeField, DisableInEditorMode]
        protected float timer;

        [BoxGroup("反應頁/反應頁/正確分數"), SerializeField]
        public Score correctScore { get; protected set; }

        [BoxGroup("反應頁/反應頁/正確的點擊時間"), ShowInInspector, DisableInEditorMode]
        public List<float> correctTime { get; protected set; }

        [BoxGroup("反應頁/反應頁/錯誤分數")]
        public Score wrongScore { get; protected set; }

        [BoxGroup("反應頁/反應頁/錯誤的點擊時間"), ShowInInspector, DisableInEditorMode]
        public List<float> wrongTime { get; protected set; }


        [ShowInInspector] public bool isAllClick { get; private set; }

        void OnEnable()
        {
            correctScore = new Score();
            wrongScore = new Score();
            isCounting = true;
            timer = new float();
            correctTime = new List<float>();
            wrongTime = new List<float>();
            isClicks.Clear();
            isAllClick = false;
            AddClick();
        }

        private void Update()
        {
            if (isCounting)
            {
                timer += Time.deltaTime;
            }
        }

        public void CheckAllClicked()
        {
            for (int i = 0; i < isClicks.Count; i++)
            {
                if (!isClicks[i])
                {
                    isClicks[i] = true;
                    if (i == isClicks.Count - 1 && isClicks[i])
                    {
                        isCounting = false;
                        isAllClick = true;
                    }

                    return;
                }
            }
        }

        public void DeClick()
        {
            for (int i = 0; i < isClicks.Count; i++)
            {
                if (isClicks[i])
                {
                    isClicks[i] = false;
                    return;
                }
            }
        }

        protected override IEnumerator SetNext(bool boolean)
        {
            yield return new WaitForSeconds(fadeInSecond);
            foreach (Item item in items)
            {
                item.Reset();
            }

            yield return base.SetNext(boolean);
        }

        public void ShowWrongPage()
        {
            foreach (Item item in items)
            {
                item.Reset();
            }

            wrongNext.SetActive(true);
            gameObject.SetActive(false);
        }


        public void SetSprite(int index, int databaseItemLocation, Sprite databaseSprite)
        {
            if (index == databaseItemLocation)
            {
                items[index].ChangeSprite(databaseSprite);
            }
        }


        protected virtual void AddClick()
        {
        }

        public void AddCorrectScore(int newScore)
        {
            correctScore.AddScore(newScore);
        }

        public void AddWrongScore(int newScore)
        {
            wrongScore.AddScore(newScore);
        }

        public void AddCorrectTime()
        {
            if (correctTime.Count == 0 && wrongTime.Count == 0)
            {
                correctTime.Add(timer);
            }
            else
            {
                if ( wrongTime.Count != 0)
                {
                    correctTime.Add(timer - wrongTime[^1]);
                }

                else if (correctTime.Count != 0)
                {
                    correctTime.Add(timer - correctTime[^1]);
                }

            }
        }

        public void AddWrongTime()
        {
            if (correctTime.Count == 0 && wrongTime.Count == 0)
            {
                wrongTime.Add(timer);
            }
            else
            {
                if ( wrongTime.Count != 0)
                {
                    wrongTime.Add(timer - wrongTime[^1]);
                }

                if (correctTime.Count != 0)
                {
                    wrongTime.Add(timer - correctTime[^1]);
                }

            }
        }

        public void NewRecord()
        {
            manager.CurrentRecord.SetCorrectScore(correctScore.totalScore.ToString());
            manager.CurrentRecord.SetWrongScore(wrongScore.totalScore.ToString());
            for (int i = 0; i < correctTime.Count; i++)
            {
                manager.CurrentRecord.AddCorrectTime(correctTime[i].ToString("0.00"));
            }
            for (int i = 0; i < wrongTime.Count; i++)
            {
                manager.CurrentRecord.AddWrongTime(wrongTime[i].ToString("0.00"));
            }
        }

#if UNITY_EDITOR
        [Button]
        public void AddItems()
        {
            items.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Item>())
                {
                    items.Add(transform.GetChild(i).GetComponent<Item>());
                }
            }
        }
#endif
    }
}