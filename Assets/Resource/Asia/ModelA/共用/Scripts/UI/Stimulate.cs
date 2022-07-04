using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using Global.SFX;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Asia.UI
{
    public class Stimulate : ImageController
    {
        [SerializeField] List<Target> targets;
        [SerializeField, Required] private AudioController audio;

        [SerializeField] private List<bool> isClicks;

        public int TargetsCount => targets.Count;

        private bool isOver;

        private void OnEnable()
        {
            StartCoroutine(CoPlayStimulateGuid());
        }

        private void Start()
        {
        }

        public void Click(int index)
        {
            isClicks[index] = true;
            for (int i = 0; i < isClicks.Count; i++)
            {
                if (!isClicks[i])
                {
                    return;
                }

                if (i == isClicks.Count - 1 && isClicks[i])
                {
                    StartCoroutine(CoShowNext());
                }
            }
        }


        public void ChangeTargetsSprite(int index, Sprite sprite)
        {
            targets[index].ChangeSprite(sprite);
        }


        IEnumerator CoPlayStimulateGuid()
        {
            isClicks.Clear();
            for (int i = 0; i < targets.Count; i++)
            {
                isClicks.Add(false);
                targets[i].trigger = false;
            }

            audio.PlayOneShot(0);
            yield return new WaitForSeconds(audio.clipTime(0));
            isOver = true;
            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].trigger = true;
            }
        }

        IEnumerator CoShowNext()
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].ResetPosition();
            }

            SetNextActive(true);
        }


#if UNITY_EDITOR
        [Button]
        public void AddITargets()
        {
            targets.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Target>())
                {
                    targets.Add(transform.GetChild(i).GetComponent<Target>());
                }
            }
        }
#endif
    }
}