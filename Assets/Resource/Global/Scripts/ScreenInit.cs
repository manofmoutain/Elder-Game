using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenInit : MonoBehaviour
{
#if PLATFORM_ANDROID


    [SerializeField] private ScreenControl ScreenControl;
    [SerializeField] private ScreenPortrait screenPortrait = ScreenPortrait.橫放;

    private void Awake()
    {
        ScreenControl = new ScreenControl();
    }

    private void Start()
    {
        switch (screenPortrait)
        {
            case ScreenPortrait.直立:
                ScreenControl.ScreenPortrait();
                break;

            case ScreenPortrait.橫放:
                ScreenControl.ScreenLandscape();
                break;
        }
    }

#endif
}