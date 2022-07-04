using System;
using System.Collections;
using System.Collections.Generic;
using Global.ImageControl;
using UnityEngine;

namespace Asia.UI
{
    public class Blank : ImageController
    {
        private void OnEnable()
        {
            SetNextActive(true);
        }
    }
}

