using System;
using System.Collections;
using System.Collections.Generic;
using Global.Scene;
using UnityEngine;
using UnityEngine.UI;

namespace Asia.UI
{
    public class AsiaPage : MonoBehaviour
    {
        private SceneLoader LoadScenes;

        [SerializeField] private Button chinaBtn;
        [SerializeField] private Button philipineBtn;
        [SerializeField] private Button japanBtn;
        [SerializeField] private Button thailandBtn;
        [SerializeField] private Button taiwanBtn;
        [SerializeField] private Button vietnamBtn;

        private void Start()
        {
            LoadScenes = new SceneLoader();

            chinaBtn.onClick.AddListener(delegate { LoadScenes.LoadScene("1-1-China"); });
            philipineBtn.onClick.AddListener(delegate { LoadScenes.LoadScene("1-2-Philippine"); });
            japanBtn.onClick.AddListener(delegate { LoadScenes.LoadScene("1-3-Japan"); });
            thailandBtn.onClick.AddListener(delegate { LoadScenes.LoadScene("1-4-Thai"); });
            taiwanBtn.onClick.AddListener(delegate { LoadScenes.LoadScene("1-5-Taiwan"); });
            vietnamBtn.onClick.AddListener(delegate { LoadScenes.LoadScene("1-6-Vietnam"); });
        }
    }
}