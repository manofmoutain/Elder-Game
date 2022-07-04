using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Global.SFX
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        [SerializeField] protected List<AudioClip> clips;
        [SerializeField,Required]
        private AudioSource audioSource;

        private void OnEnable()
        {
            if (GetComponent<AudioSource>())
            {
                audioSource = GetComponent<AudioSource>();
            }
            else
            {
                gameObject.AddComponent<AudioSource>();
                audioSource = GetComponent<AudioSource>();
            }
        }

        private void Start()
        {
            if (GetComponent<AudioSource>())
            {
                audioSource = GetComponent<AudioSource>();
            }
            else
            {
                gameObject.AddComponent<AudioSource>();
                audioSource = GetComponent<AudioSource>();
            }
        }


        public void PlayOneShot(int index)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[index]);
        }

        public float clipTime(int index) => clips[index].length;

        public void PlayBGM()
        {
            StartCoroutine(CoPlayBGN());
        }

        IEnumerator CoPlayBGN()
        {
            int r = Random.Range(0, clips.Count);
            float timer = clips[r].length;
            audioSource.clip = clips[r];
            audioSource.loop = false;
            yield return new WaitForSeconds(0.5f);
            audioSource.Play();
            yield return new WaitForSeconds(timer);
            audioSource.Stop();
            PlayBGM();
        }


        public void Clear()
        {
            clips.Clear();
        }

        public void Add(AudioClip clip)
        {
            clips.Add(clip);
        }
    }
}