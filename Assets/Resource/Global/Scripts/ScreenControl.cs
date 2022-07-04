using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using Screen = UnityEngine.Device.Screen;


public class ScreenControl
{
    public void ScreenPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        // 設定是否可以 正向
        Screen.autorotateToPortrait = true;

// 設定是否可以 倒向
        Screen.autorotateToPortraitUpsideDown = false;

        // 設定是否可以 向左倒
        Screen.autorotateToLandscapeLeft = false;
        // 設定是否可以 向右倒
        Screen.autorotateToLandscapeRight = false;
    }

    public void ScreenLandscape()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;

        // 設定是否可以 正向
        Screen.autorotateToPortrait = false;

// 設定是否可以 倒向
        Screen.autorotateToPortraitUpsideDown = false;

        // 設定是否可以 向左倒
        Screen.autorotateToLandscapeLeft = true;
        // 設定是否可以 向右倒
        Screen.autorotateToLandscapeRight = true;
    }
}

public enum ScreenPortrait
{
    直立,
    橫放
}