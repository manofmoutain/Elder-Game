using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global.Scene
{
    [Serializable]
    public class SceneLoader
    {


        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}

