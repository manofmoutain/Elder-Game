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

        private void Start()
        {
            LoadScenes = new SceneLoader();

            chinaBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(1); });
            philipineBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(2); });
            japanBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(3); });
            thailandBtn.onClick.AddListener(delegate { LoadScenes.LoadScene(4); });
        }
    }
}