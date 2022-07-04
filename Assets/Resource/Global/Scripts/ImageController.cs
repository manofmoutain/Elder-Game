using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Global.ImageControl
{
    public class ImageController : MonoBehaviour
    {
        [TitleGroup("控制"),FoldoutGroup("控制/收合"),BoxGroup("控制/收合/要啟用的下一個"),SerializeField] protected ImageController next;
        [BoxGroup("控制/收合/過場時間"),SerializeField] protected float fadeInSecond = 1;

        public void SetActive(bool boolean)
        {
            gameObject.SetActive(boolean);
        }

        public virtual void SetNextActive(bool boolean)
        {
            StartCoroutine(SetNext(boolean));
        }

        protected virtual IEnumerator SetNext(bool boolean)
        {
            yield return new WaitForSeconds(fadeInSecond);
            SetActive(!boolean);
            next.SetActive(boolean);
        }

        public void ChangeSprite(Sprite sprite)
        {
            GetComponent<Image>().sprite = sprite;
        }

        public void ChangeNextImage(ImageController newNext)
        {
            next = newNext;
        }
    }
}

