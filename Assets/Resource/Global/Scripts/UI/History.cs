using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;

namespace Global.UI
{
    public class History : MonoBehaviour
    {
        [SerializeField, Required] private TMP_Dropdown asiaDrop;
        [SerializeField] private List<HistoryRecordPage> recordPage;

        [SerializeField, Required] private List<HistoryRecord> records;

        private void OnEnable()
        {
            asiaDrop.value = 0;
        }


        private void Start()
        {
            records.Clear();
            asiaDrop.onValueChanged.AddListener(delegate
            {
                switch (asiaDrop.value)
                {
                    case 0:
                        for (int i = 0; i < recordPage.Count; i++)
                        {
                            recordPage[i].gameObject.SetActive(false);
                        }

                        break;
                    case 1:
                        ChangeModelA("中國");
                        break;

                    case 2:
                        ChangeModelA("菲律賓");
                        break;

                    case 3:
                        ChangeModelA("日本");

                        break;

                    case 4:
                        ChangeModelA("泰國");
                        break;

                    case 5 :
                        ChangeModelC("台灣");
                        break;
                }
            });
        }


        void ChangeModelA(string nation)
        {
            for (int i = 0; i < recordPage.Count; i++)
            {
                recordPage[i].gameObject.SetActive(false);
            }

            records.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    records.Add(recordPage[i].records[j]);
                    recordPage[i].records[j].Clear();
                    if (i == 3)
                    {
                        recordPage[i].ChangeNextImage(recordPage[0]);
                    }
                    else
                    {
                        recordPage[i].ChangeNextImage(recordPage[i + 1]);
                    }
                }
            }

            if (PlayerPrefs.GetString($"亞洲-{nation}-1") != "")
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Set($"亞洲-{nation}-{i + 1}");
                }
            }

            if (PlayerPrefs.GetString($"亞洲-{nation}-21") != "")
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Set($"亞洲-{nation}-{i + 21}");
                }
            }


            if (PlayerPrefs.GetString($"亞洲-{nation}-41") != "")
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Set($"亞洲-{nation}-{i + 41}");
                }
            }

            recordPage[0].gameObject.SetActive(true);
        }

        void ChangeModelC(string nation)
        {
            for (int i = 0; i < recordPage.Count; i++)
            {
                recordPage[i].gameObject.SetActive(false);
            }

            records.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    records.Add(recordPage[i].records[j]);
                    recordPage[i].records[j].Clear();
                    if (i == 7)
                    {
                        recordPage[i].ChangeNextImage(recordPage[0]);
                    }
                    else
                    {
                        recordPage[i].ChangeNextImage(recordPage[i + 1]);
                    }
                }
            }

            if (PlayerPrefs.GetString($"亞洲-{nation}-1") != "")
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Set($"亞洲-{nation}-{i + 1}");
                }
            }

            if (PlayerPrefs.GetString($"亞洲-{nation}-41") != "")
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Set($"亞洲-{nation}-{i + 41}");
                }
            }


            if (PlayerPrefs.GetString($"亞洲-{nation}-81") != "")
            {
                for (int i = 0; i < records.Count; i++)
                {
                    records[i].Set($"亞洲-{nation}-{i + 81}");
                }
            }

            recordPage[0].gameObject.SetActive(true);

        }
    }
}