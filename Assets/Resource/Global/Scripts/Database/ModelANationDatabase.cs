using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Database
{
    public class ModelANationDatabase : ScriptableObject
    {
        [Title("區域設定")]
        public Area area;

        [TitleGroup("項目設定")]
        [VerticalGroup("項目設定/Split")]
        [BoxGroup("項目設定/Split/題組"), EnumToggleButtons, HideLabel, TableColumnWidth(80, Resizable = false),SerializeField]
        public QuestionGroup group;

        [BoxGroup("項目設定/Split/難易度"), HideLabel, EnumToggleButtons,SerializeField]
        public Difficulties Difficulties;

        [TitleGroup("目標圖片")]
        [BoxGroup("目標圖片/目標圖片")]
        [HideLabel]
        public List<TargetData> TargetDatas;

        [TitleGroup("錯誤圖片")]
        [BoxGroup("錯誤圖片/錯誤圖片"), HideLabel]
        public List<ItemData> items;

        [TitleGroup("回饋圖"), BoxGroup("回饋圖/回饋圖"), HideLabel]
        public FeedBack feedback;
    }
}

