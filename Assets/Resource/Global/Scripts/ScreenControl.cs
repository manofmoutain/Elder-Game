using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using Screen = UnityEngine.Device.Screen;


public class ScreenControl
{
    public void ScreenPortrait()
    {
#if UNITY_STANDALONE_OSX
        Screen.SetResolution(608, 1080, FullScreenMode.Windowed);
#endif

#if UNITY_STANDALONE_WIN
        Screen.SetResolution(608,1080,FullScreenMode.Windowed);
#endif


#if PLATFORM_ANDROID
        Screen.orientation = ScreenOrientation.Portrait;

        // 設定是否可以 正向
        Screen.autorotateToPortrait = true;

        // 設定是否可以 倒向
        Screen.autorotateToPortraitUpsideDown = false;

        // 設定是否可以 向左倒
        Screen.autorotateToLandscapeLeft = false;
        // 設定是否可以 向右倒
        Screen.autorotateToLandscapeRight = false;
        Screen.SetResolution(1080,1920,FullScreenMode.Windowed);
#endif
    }

    public void ScreenLandscape()
    {
#if UNITY_STANDALONE_OSX
        Screen.SetResolution(1840, 1035, FullScreenMode.Windowed);
#endif

#if UNITY_STANDALONE_WIN
        Screen.SetResolution(1840,1035,FullScreenMode.Windowed);
#endif
#if PLATFORM_ANDROID
        Screen.orientation = ScreenOrientation.LandscapeRight;

        // 設定是否可以 正向
        Screen.autorotateToPortrait = false;

        // 設定是否可以 倒向
        Screen.autorotateToPortraitUpsideDown = false;

        // 設定是否可以 向左倒
        Screen.autorotateToLandscapeLeft = true;
        // 設定是否可以 向右倒
        Screen.autorotateToLandscapeRight = true;
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
#endif
    }
}

public enum ScreenPortrait
{
    直立,
    橫放
}