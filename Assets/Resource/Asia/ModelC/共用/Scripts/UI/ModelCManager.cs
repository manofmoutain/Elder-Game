using System;
using System.Collections;
using System.Collections.Generic;
using Global.Database;
using Global.Scene;
using Global.Score;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asia.UI.ModelC
{
    public class ModelCManager : MonoBehaviour
    {
        [TitleGroup("資料庫"), TabGroup("資料庫/Parameters", "總資料庫"), SerializeField]
        protected List<ModelCNationDatabase> AllData;

        [TabGroup("資料庫/Parameters", "群組資料庫"), SerializeField]
        protected List<ModelCNationDatabase> groupData;

        [TabGroup("資料庫/Parameters", "正在使用資料庫"), ShowInInspector]
        public ModelCNationDatabase currentData { get; protected set; }

        public int CurrentDataTargetCount => currentData.TargetDatas.Count;

        [TitleGroup("暫存"), ShowInInspector] protected Dictionary<string, TargetData> targetDic;
        [TitleGroup("暫存"), ShowInInspector] public Sprite spriteTemp { get; protected set; }

        [TitleGroup("暫存"), SerializeField, Required]
        private ModelCSample sample;

        [TitleGroup("紀錄"),BoxGroup("紀錄/紀錄"), SerializeField, Required]
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
                    if (record.dataBaseIndex == currentData.name)
                    {
                        _re = record;
                        break;
                    }
                }

                return _re;
            }

            set { }
        }

        // [Button]
        public bool DicHasValue(string _name)
        {
            return targetDic.ContainsKey(_name);
        }

        private void Start()
        {
            Init();
        }

        protected virtual void Init()
        {
            achievePercent = 0;
            targetDic = new Dictionary<string ,TargetData>();
            records = new List<Record>();
            int a = Random.Range(0, 3);
            for (int i = 0; i < AllData.Count; i++)
            {
                if ((int)AllData[i].group == a)
                {
                    Record _new = new Record();
                    _new.dataBaseIndex = AllData[i].name;
                    records.Add(_new);
                    groupData.Add(AllData[i]);
                }
            }

            float _percent = groupData.Count + 0.0f;
            achieve = 100 / _percent;


            for (int i = 0; i < AllData.Count; i++)
            {
                int b = Random.Range(0, AllData.Count);
                if (AllData[b].items.Count!=0 && (int)AllData[b].group!=a)
                {
                    spriteTemp = AllData[b].items[0].sprite;
                    sample.SetPicture(spriteTemp);
                    break;
                }
            }
        }


        public virtual void SetCurrentData()
        {
            if (groupData.Count==0)
            {
                for (int i = 0; i < AllData.Count; i++)
                {
                    if (PlayerPrefs.GetString($"{AllData[i].name}") != "")
                    {
                        PlayerPrefs.DeleteKey($"{AllData[i].name}");
                        PlayerPrefs.DeleteKey($"{AllData[i].name}-正確分數");
                        PlayerPrefs.DeleteKey($"{AllData[i].name}-正確反應0");
                        PlayerPrefs.DeleteKey($"{AllData[i].name}-正確反應1");
                        PlayerPrefs.DeleteKey($"{AllData[i].name}-錯誤分數");
                        PlayerPrefs.DeleteKey($"{AllData[i].name}-錯誤反應0");
                        PlayerPrefs.DeleteKey($"{AllData[i].name}-錯誤反應1");
                    }
                }
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

                if (achievePercent < 80.0f)
                {
                    Init();
                    sample.SetActive(true);
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
            currentData = groupData[0];
            groupData.RemoveAt(0);
        }

        public void AddDicValue(string _name)
        {
            if (CurrentDataTargetCount != 0)
            {
                if (!DicHasValue(_name))
                {
                    targetDic.Add(currentData.TargetDatas[0].sprite.name ,currentData.TargetDatas[0]);
                }
            }

        }

        public void CorrectAnswer()
        {
            achievePercent += achieve;
        }
    }
}