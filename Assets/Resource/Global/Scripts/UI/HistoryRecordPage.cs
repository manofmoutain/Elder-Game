using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Global.UI
{
    public class HistoryRecordPage : ImageController,IPointerClickHandler
    {
        [SerializeField] public List<HistoryRecord> records;


        public void OnPointerClick(PointerEventData eventData)
        {
            SetNextActive(true);
        }
    }
}

