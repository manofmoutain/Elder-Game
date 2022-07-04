using System;
using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Global.ImageControl;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asia.UI.ModelA
{
    public class Item : ImageController , IPointerClickHandler
    {
        [TitleGroup("反應圖片"),FoldoutGroup("反應圖片/反應圖片"),BoxGroup("反應圖片/反應圖片/反應頁"),SerializeField, Required] protected Reaction reaction;
        // [BoxGroup("反應圖片/反應圖片/原始座標"),SerializeField,DisableInInlineEditors] protected Vector2 originPosition;
        [BoxGroup("反應圖片/反應圖片/是否已點擊"),SerializeField,DisableInInlineEditors] public bool isClicked;
        [BoxGroup("反應圖片/反應圖片/移動幅度"),SerializeField] protected float moveValue = 10;
        [ShowInInspector] public bool isChecked { get; protected set; }

        private void OnEnable()
        {
            Reset();

        }

        private void Start()
        {
            // originPosition = GetComponent<RectTransform>().localPosition;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isClicked)
            {
                isClicked = true;
                reaction.CheckAllClicked();
                GetComponent<RectTransform>().offsetMin=new Vector2(-moveValue,moveValue);
                GetComponent<RectTransform>().offsetMax=new Vector2(-moveValue,moveValue);
                Check();
            }
            else
            {
                // isClicked = false;
                // reaction.DeClick();
                // GetComponent<RectTransform>().offsetMin=new Vector2(0,0);
                // GetComponent<RectTransform>().offsetMax=new Vector2(0,0);
                // Cancel();
            }
        }

        public void Reset()
        {
            isClicked = false;
            isChecked = false;
            GetComponent<RectTransform>().offsetMin=new Vector2(0,0);
            GetComponent<RectTransform>().offsetMax=new Vector2(0,0);
        }


        protected virtual void Check()
        {

        }

        protected virtual void Cancel()
        {

        }
    }
}

