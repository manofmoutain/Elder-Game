using System;
using System.Collections;
using System.Collections.Generic;
using Asia.UI;
using Global.ImageControl;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asia
{
    public class Target : ImageController , IPointerClickHandler
    {
        [SerializeField, Required] private Stimulate stimulate;
        public bool trigger;
        public bool isClicked;
        [SerializeField] private int index;
        [SerializeField] protected Vector2 originPosition;
        [SerializeField] protected float moveValue = 10;

        private void OnEnable()
        {
            trigger = false;
            isClicked = false;
        }

        private void Start()
        {
            originPosition = GetComponent<RectTransform>().localPosition;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (trigger && !isClicked)
            {
                isClicked = true;
                GetComponent<RectTransform>().localPosition = new Vector3(originPosition.x-moveValue , originPosition.y+moveValue);
                stimulate.Click(index);
            }
        }

        public void ResetPosition()
        {
            GetComponent<RectTransform>().localPosition = originPosition;
        }
    }
}

