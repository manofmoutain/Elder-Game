using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Global.Database;
using Global.Scene;
using Global.Score;
using Global.SFX;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asia.UI.ModelA
{
    public class GroupManager : MonoBehaviour
    {
        [TitleGroup("資料庫"), Required, SerializeField]
        protected Modle_A_Database data;

        [TitleGroup("群組物件(困難度)")] [BoxGroup("群組物件(困難度)/群組"), SerializeField, HideLabel, Required]
        protected List<Group> groups;

        [TitleGroup("音效"), BoxGroup("音效/背景"), SerializeField, Required]
        private AudioController bgmPlayer;

        [TitleGroup("開始頁面"), BoxGroup("開始頁面/開始頁面"), SerializeField, Required]
        protected StartPage startPage;

        public Modle_A_Database Data => data;

        [TitleGroup("紀錄"), BoxGroup("紀錄/紀錄列表"), SerializeField]
        protected List<Record> records;

        [BoxGroup("紀錄/每一題的達成率"), SerializeField]
        protected float achieve;

        [BoxGroup("紀錄/的達成率"), SerializeField] protected float achievePercent;

        public Record CurrentRecord
        {
            get
            {
                Record _re = new Record();
                foreach (Record record in records)
                {
                    if (record.dataBaseIndex == data.CurrentDatabases.name)
                    {
                        _re = record;
                        break;
                    }
                }

                return _re;
            }

            set { }
        }

        [ShowInInspector] public bool CheckItem1 { get; protected set; }
        [ShowInInspector] public bool CheckItem2 { get; protected set; }

        [ShowInInspector] public bool CheckItem3 { get; protected set; }

        protected virtual void Start()
        {
            startPage.SetActive(true);
            InitializeGroup();
            bgmPlayer.PlayBGM();
        }

        public virtual void ShowWrongPage()
        {
            groups[(int)data.CurrentDatabases.Difficulties].Reaction.ShowWrongPage();
        }

        public virtual void ShowFeedBack()
        {
            achievePercent += achieve;
            ResetChecks();
            groups[(int)data.CurrentDatabases.Difficulties].Reaction.SetNextActive(true);
        }

        public void ResetChecks()
        {
            CheckItem1 = false;
            CheckItem2 = false;
            CheckItem3 = false;
        }

        protected virtual void InitializeGroup()
        {
            records = new List<Record>();
            achievePercent = 0;
            data.ResetCurrentGroup();
            int a = Random.Range(0, 3);
            foreach (ModelANationDatabase database in data.Databases)
            {
                if ((int)database.group == a)
                {
                    Record _record = new Record();
                    _record.SetIndex(database.name);
                    records.Add(_record);
                    data.AddGroup(database);
                }
            }

            achieve = 100.0f / data.CurrentGroupListCount;
        }

        // [Button("隨奇蹄目")]
        public virtual void ChangeCurrentDatabase()
        {
            int a = Random.Range(0, data.CurrentGroupListCount);
            if (data.CurrentGroupListCount == 0)
            {
                for (int i = 0; i < data.Databases.Count; i++)
                {
                    if (PlayerPrefs.GetString($"{data.Databases[i].name}") != "")
                    {
                        PlayerPrefs.DeleteKey($"{data.Databases[i].name}");
                        PlayerPrefs.DeleteKey($"{data.Databases[i].name}-正確分數");
                        PlayerPrefs.DeleteKey($"{data.Databases[i].name}-正確反應0");
                        PlayerPrefs.DeleteKey($"{data.Databases[i].name}-正確反應1");
                        PlayerPrefs.DeleteKey($"{data.Databases[i].name}-錯誤分數");
                        PlayerPrefs.DeleteKey($"{data.Databases[i].name}-錯誤反應0");
                        PlayerPrefs.DeleteKey($"{data.Databases[i].name}-錯誤反應1");
                    }
                }

                if (achievePercent <= 80.0f)
                {
                    InitializeGroup();
                    startPage.SetActive(true);
                    return;
                }
                else
                {
                    for (int i = 0; i < records.Count; i++)
                    {
                        PlayerPrefs.SetString($"{records[i].dataBaseIndex}", $"{records[i].dataBaseIndex}");
                        PlayerPrefs.SetString($"{records[i].dataBaseIndex}-正確分數", $"{records[i].correctScore}");
                        for (int j = 0; j < records[i].correctTime.Count; j++)
                        {
                            PlayerPrefs.SetString($"{records[i].dataBaseIndex}-正確反應{j}", $"{records[i].correctTime[j]}秒");
                        }

                        PlayerPrefs.SetString($"{records[i].dataBaseIndex}-錯誤分數", $"{records[i].wrongScore}");
                        for (int j = 0; j < records[i].wrongTime.Count; j++)
                        {
                            PlayerPrefs.SetString($"{records[i].dataBaseIndex}-錯誤反應{j}", $"{records[i].wrongTime[j]}秒");
                        }
                    }

                    SceneLoader _sceneLoader = new SceneLoader();
                    _sceneLoader.LoadScene(0);
                    return;
                }
            }

            data.SetCurrentDatabase(data.CurrentGroupList[a]);
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].SetActive(i == (int)data.CurrentDatabases.Difficulties);
                if (groups[i].gameObject.activeSelf)
                {
                    for (int j = 0; j < groups[i].Stimulate.TargetsCount; j++)
                    {
                        groups[i].Stimulate.ChangeTargetsSprite(j, data.CurrentDatabases.TargetDatas[j].sprite);
                    }

                    for (int j = 0; j < groups[i].Reaction.items.Count; j++)
                    {
                        for (int k = 0; k < data.CurrentDatabases.TargetDatas.Count; k++)
                        {
                            groups[i].Reaction.SetSprite(j, (int)data.CurrentDatabases.TargetDatas[k].location,
                                data.CurrentDatabases.TargetDatas[k].sprite);
                        }

                        for (int k = 0; k < data.CurrentDatabases.items.Count; k++)
                        {
                            groups[i].Reaction.SetSprite(j, (int)data.CurrentDatabases.items[k].location,
                                data.CurrentDatabases.items[k].sprite);
                        }
                    }

                    groups[i].feedBackPage.SetFeedBackText(data.CurrentDatabases.feedback.feedbackText);
                    groups[i].feedBackPage.SetFeedBackImage(data.CurrentDatabases.feedback.feedback);
                    groups[i].feedBackPage.SetPoint(data.CurrentDatabases.feedback.feedbackPoint);
                    groups[i].feedBackPage.SetSFX(data.CurrentDatabases.feedback.feedbackSFX);
                    groups[i].Stimulate.SetActive(true);
                    ResetChecks();
                    data.RemoveAt(a);
                }
            }
        }

        protected virtual IEnumerator CoChangeCurrentDatabase(bool boolean)
        {
            yield return new WaitUntil(() => boolean);
            ChangeCurrentDatabase();
        }
    }
}