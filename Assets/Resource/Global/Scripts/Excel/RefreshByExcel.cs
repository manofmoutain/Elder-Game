#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Asia;
using Asia.Database;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Global.Database
{
    public class RefreshByExcel : MonoBehaviour
    {
        [TitleGroup("路徑"), FoldoutGroup("路徑/路徑")] [BoxGroup("路徑/路徑/路徑"), HideLabel, SerializeField]
        string path;

        [BoxGroup("路徑/路徑/檔案名稱"), SerializeField, HideLabel]
        string fileName;

        [BoxGroup("路徑/路徑/sheet名稱"), HideLabel, SerializeField]
        string sheetName;

        LoadExcel LoadExcel;
        private LoadColumns LoadColumns;


        [TitleGroup("資料庫資訊"), FoldoutGroup("資料庫資訊/Target"), BoxGroup("資料庫資訊/Target/橫")] [SerializeField, HideLabel]
        protected int targetRow;

        [BoxGroup("資料庫資訊/Target/檔案編號")] [SerializeField, HideLabel]
        protected int targetColumn;

        [BoxGroup("資料庫資訊/Target/數量")] [SerializeField, HideLabel]
        protected int targetCount;

        [BoxGroup("資料庫資訊/Target/位置")] [SerializeField, HideLabel]
        protected int targetLocationColumn;

        [BoxGroup("資料庫資訊/Target/位置數量")] [SerializeField, HideLabel]
        protected int targetLocationCount;

        [BoxGroup("資料庫資訊/Target/目標圖")] [SerializeField]
        protected List<Sprite> targetSprites;


        [FoldoutGroup("資料庫資訊/Item")] [BoxGroup("資料庫資訊/Item/row")] [HideLabel, SerializeField]
        protected int itemRow;

        [BoxGroup("資料庫資訊/Item/位置")] [HideLabel, SerializeField]
        protected int itemLocationColumn;

        [BoxGroup("資料庫資訊/Item/數量")] [HideLabel, SerializeField]
        protected int itemLocationCount;

        [BoxGroup("資料庫資訊/Item/非目標")] [SerializeField]
        protected List<Sprite> itemSprites;


        [FoldoutGroup("資料庫資訊/回饋"), BoxGroup("資料庫資訊/回饋/橫")] [SerializeField, HideLabel]
        protected int feedBackRow;

        [BoxGroup("資料庫資訊/回饋/回饋文字")] [SerializeField, HideLabel]
        protected int feedBackTextColumn;

        [BoxGroup("資料庫資訊/回饋/圖片編號")] [SerializeField, HideLabel]
        protected int feedBackSpriteColumn;

        [BoxGroup("資料庫資訊/回饋/點數")] [SerializeField, HideLabel]
        protected int feedBackPointColum;

        [BoxGroup("資料庫資訊/回饋/回饋圖")] [SerializeField]
        protected List<Sprite> feedBackSprite;

        [BoxGroup("資料庫資訊/回饋/回饋語音")] [SerializeField]
        protected List<AudioClip> feedBackSFX;


        #region 更新資料庫

        /// <summary>
        /// Target
        /// </summary>
        /// <param name="row">橫列</param>
        /// <param name="targetColumn">直(目標物)</param>
        /// <param name="locationColumn">直(位置)</param>
        /// <param name="locationCount">location數量</param>
        [Button("更新Target"), GUIColor(0, 1, 0)]
        void RefreshTarget()
        {
            LoadTarget();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Item
        /// </summary>
        /// <param name="row"></param>
        /// <param name="locationColum"></param>
        [Button("更新Item"), GUIColor(0, 1, 0)]
        void RefreshItem()
        {
            LoadItems();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

        }

        /// <summary>
        /// 回饋
        /// </summary>
        /// <param name="row">橫列</param>
        /// <param name="spriteColumn">直(圖片)</param>
        /// <param name="pointColum">直(點數)</param>
        [Button("更新回饋"), GUIColor(0, 1, 0)]
        void RefreshFeedBack()
        {
            LoadFeedBack();

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        protected virtual void LoadTarget()
        {
        }

        protected virtual void LoadItems()
        {
        }

        protected virtual void LoadFeedBack()
        {
        }


        [Button]
        protected List<string> LoadTargetTexts(int i)
        {
            LoadColumns = new LoadColumns();
            return LoadColumns.ReadTargetColumns(path, fileName, sheetName, targetRow + i, targetColumn, targetCount,
                itemLocationColumn, itemLocationCount);
        }

        // [Button]
        protected List<string> LoadLocationTexts(int i)
        {
            LoadColumns = new LoadColumns();
            return LoadColumns.ReadLocationColumns(path, fileName, sheetName, itemRow + i, itemLocationColumn, itemLocationCount);
        }

        [Button]
        protected string LoadText(int rowIndex, int columnsIndex)
        {
            LoadExcel = new LoadExcel();
            return (LoadExcel.ReadExcelSimplePasses(path, fileName, sheetName, rowIndex, columnsIndex));
        }

        protected int LoadInt(int rowIndex, int columnsIndex)
        {
            LoadExcel = new LoadExcel();
            return int.Parse(LoadExcel.ReadExcelSimplePasses(path, fileName, sheetName, rowIndex, columnsIndex));
        }

        #endregion
    }
}
#endif