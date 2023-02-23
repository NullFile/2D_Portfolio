using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GlobalData : MonoBehaviour
{
    /// <summary>
    /// ���Ұ� Ȯ�� ��
    /// </summary>
    public static bool SoundCheck
    {
        get { return _MainSoundCheck; }
        set { _MainSoundCheck = value; }
    }

    /// <summary>
    /// �Ҹ� ũ�� ��
    /// </summary>
    public static float MainSound
    {
        get { return _MainSoundValue; }
        set { _MainSoundValue = value; }
    }

    /// <summary>
    /// ���� ��
    /// </summary>
    public static int ScreenWidth
    {
        set
        {
            _ScreenWidthValue = value;
            ScreenCheck();
        }
    }

    /// <summary>
    /// ���� ��
    /// </summary>
    public static int ScreenHeight
    {
        set
        {
            _ScreenHeightValue = value;
            ScreenCheck();
        }
    }

    /// <summary>
    /// ��ü ȭ�� ��
    /// </summary>
    public static bool FullScreen
    {
        get { return _FullScreenValue; }
        set
        {
            _FullScreenValue = value;
            ScreenCheck();
        }
    }

    /// <summary>
    /// �⺻ ����, ���� �� ����
    /// </summary>
    public void DefaultScreenSize()
    {
        ScreenWidth = _defaultWidthValue;
        ScreenHeight = _defaultHeightValue;
    }

    /// <summary>
    /// ���� ���� ȭ�� ũ�� �� ��ü ȭ�� ����
    /// </summary>
    static void ScreenCheck()
    {
        if (_ScreenWidthValue == 0 || _ScreenHeightValue == 0)
            return;

        Screen.SetResolution(_ScreenWidthValue, _ScreenHeightValue, _FullScreenValue);
    }

    public enum ScreenRatioType
    {
        nHD,
        qHD,
        HD,
        HD_Plus,
        FHD,
        QHD,
        QHD_Plus,
        UHD,
        UHD_Plus,
        FHUD,
    }

    /// <summary>
    /// Dropdown ��� ����
    /// </summary>
    public static ScreenRatioType ScreenRatio
    {
        get { return _screenRatioValue; }
        set 
        { 
            _screenRatioValue = value;
            SetScreenRatioSize(_screenRatioValue);
        }
    }

    /// <summary>
    /// Dropdown ���� �� ���� �Լ�
    /// </summary>
    /// <param name="ratio">ȭ�� ����</param>
    private static void SetScreenRatioSize(ScreenRatioType ratio)
    {
        _screenRatioValue = ratio;

        switch (_screenRatioValue)
        {
            case ScreenRatioType.nHD:
                { 
                    ScreenWidth = 640;
                    ScreenHeight = 360;
                }
                break;
            case ScreenRatioType.qHD:
                {
                    ScreenWidth = 960;
                    ScreenHeight = 540;
                }
                break;
            case ScreenRatioType.HD:
                {
                    ScreenWidth = 1280;
                    ScreenHeight = 720;
                }
                break;
            case ScreenRatioType.HD_Plus:
                {
                    ScreenWidth = 1600;
                    ScreenHeight = 900;
                }
                break;
            case ScreenRatioType.FHD:
                {
                    ScreenWidth = 1920;
                    ScreenHeight = 1080;
                }
                break;
            case ScreenRatioType.QHD:
                {
                    ScreenWidth = 2560;
                    ScreenHeight = 1440;
                }
                break;
            case ScreenRatioType.QHD_Plus:
                {
                    ScreenWidth = 3200;
                    ScreenHeight = 1800;
                }
                break;
            case ScreenRatioType.UHD:
                {
                    ScreenWidth = 3840;
                    ScreenHeight = 2160;
                }
                break;
            case ScreenRatioType.UHD_Plus:
                {
                    ScreenWidth = 5120;
                    ScreenHeight = 2880;
                }
                break;
            case ScreenRatioType.FHUD:
                {
                    ScreenWidth = 7680;
                    ScreenHeight = 4320;
                }
                break;
        }

        ScreenCheck();
    }

    //public static float BackGroundMusic
    //{
    //    set { _BackGroundMusicValue = value; }
    //}

    //public static float EffectSound
    //{
    //    set { _EffectSoundValue = value; }
    //}

    //void Awake()
    //{

    //}

    //void Start()
    //{

    //}

    private static int _Gold = 1500;

    public static int UserGold 
    { get { return _Gold; } set { _Gold = value; } }

    public static bool[] skill = new bool[(int)Skill.Null - 1] { false, false, false, false, false, false, false };

    public static void LoadData()
    {
        UserGold = PlayerPrefs.GetInt("UserGold", 1500);

        for (int i = 0; i < skill.Length; i++)
        {
            string key = "UserSkill_" + i;

            skill[i] = System.Convert.ToBoolean(PlayerPrefs.GetInt(key));
        }
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("UserGold", UserGold);

        for (int i = 0; i < skill.Length; i++)
        {
            string key = "UserSkill_" + i;

            PlayerPrefs.SetInt(key, System.Convert.ToInt16(skill[i]));
        }
    }

    public static void ResetData()
    {
        UserGold = 1500;

        for (int i = 0; i < skill.Length; i++)
        {
            skill[i] = false;
        }

        PlayerPrefs.DeleteAll();
    }
}
