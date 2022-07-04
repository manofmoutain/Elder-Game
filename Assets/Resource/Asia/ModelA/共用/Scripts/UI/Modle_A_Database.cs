using System.Collections;
using System.Collections.Generic;
using Asin.China.Database;
using Global.Database;
using Global.Score;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Asia.UI
{
    public class Modle_A_Database : MonoBehaviour
    {
        [TitleGroup("資料庫")] [TabGroup("資料庫/Parameters", "目前試題群組"), HideLabel] [SerializeField]
        private List<ModelANationDatabase> currentQuestGroup;

        public List<ModelANationDatabase> CurrentGroupList => currentQuestGroup;
        public int CurrentGroupListCount => currentQuestGroup.Count;

        [TabGroup("資料庫/Parameters", "資料庫"), HideLabel] [SerializeField]
        private List<ModelANationDatabase> dataBases;

        public List<ModelANationDatabase> Databases => dataBases;

        [TabGroup("資料庫/Parameters", "目前使用資料庫"), HideLabel] [SerializeField]
        protected ModelANationDatabase currentDatabases;

        public ModelANationDatabase CurrentDatabases => currentDatabases;
        // [TitleGroup("群組物件(困難度)")] [BoxGroup("群組物件(困難度)/群組"), SerializeField, HideLabel, Required]
        // protected List<Group> groups;

        public void ResetCurrentGroup()
        {
            if (currentQuestGroup.Count > 0)
            {
                currentQuestGroup.Clear();
            }
        }

        public void AddGroup(ModelANationDatabase newData)
        {
            currentQuestGroup.Add(newData);
        }

        public void RemoveAt(int index)
        {
            currentQuestGroup.RemoveAt(index);
        }

        public virtual void SetCurrentDatabase(ModelANationDatabase newData)
        {
            currentDatabases = newData;
        }
    }
}