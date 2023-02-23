using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GlobalData : MonoBehaviour
{
    /// <summary>
    /// 음소거 변수
    /// </summary>
    private static bool _MainSoundCheck = true;
    /// <summary>
    /// 소리 크기 변수
    /// </summary>
    private static float _MainSoundValue = 1.0f;

    /// <summary>
    /// 기본 가로 변수
    /// </summary>
    private static int _defaultWidthValue = 1280;
    /// <summary>
    /// 기본 세로 변수
    /// </summary>
    private static int _defaultHeightValue = 720;

    /// <summary>
    /// 가로 변수
    /// </summary>
    private static int _ScreenWidthValue = 1280;
    /// <summary>
    /// 세로 변수
    /// </summary>
    private static int _ScreenHeightValue = 720;

    /// <summary>
    /// 전체 화면 변수
    /// </summary>
    private static bool _FullScreenValue = false;

    /// <summary>
    /// 화면 비율 변수
    /// </summary>
    private static ScreenRatioType _screenRatioValue = ScreenRatioType.HD;

    //private static float _BackGroundMusicValue = 0.0f;
    //private static float _EffectSoundValue = 0.0f;

    #region Global Prefabs
    public static GameObject configPrefab = 
        Resources.Load("Prefabs/Global/Config/Config_Panel") as GameObject;
    public static GameObject noticePrefab = 
        Resources.Load("Prefabs/Global/Notice/Notice_Panel") as GameObject;
    #endregion

    //private static Sprite sprite = (Sprite)Resources.Load("");
}
