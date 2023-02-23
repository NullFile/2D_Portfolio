using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GlobalData : MonoBehaviour
{
    /// <summary>
    /// ���Ұ� ����
    /// </summary>
    private static bool _MainSoundCheck = true;
    /// <summary>
    /// �Ҹ� ũ�� ����
    /// </summary>
    private static float _MainSoundValue = 1.0f;

    /// <summary>
    /// �⺻ ���� ����
    /// </summary>
    private static int _defaultWidthValue = 1280;
    /// <summary>
    /// �⺻ ���� ����
    /// </summary>
    private static int _defaultHeightValue = 720;

    /// <summary>
    /// ���� ����
    /// </summary>
    private static int _ScreenWidthValue = 1280;
    /// <summary>
    /// ���� ����
    /// </summary>
    private static int _ScreenHeightValue = 720;

    /// <summary>
    /// ��ü ȭ�� ����
    /// </summary>
    private static bool _FullScreenValue = false;

    /// <summary>
    /// ȭ�� ���� ����
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
