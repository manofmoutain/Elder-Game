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

        private void Start()
        {
            LoadScenes = new SceneLoader();

            chinaBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(8); });
            philipineBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(9); });
            japanBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(10); });
            thailandBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(11); });
            taiwanBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(12); });
        }
    }
}