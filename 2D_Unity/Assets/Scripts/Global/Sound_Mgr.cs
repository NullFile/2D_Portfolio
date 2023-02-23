using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Mgr : MonoBehaviour
{
    public static Sound_Mgr instance;

    private new AudioSource audio;

    int playSoundIdx = 0;
    int effSoundCount = 5;

    private Dictionary<string, AudioClip> clipList = new Dictionary<string, AudioClip>();
    private List<AudioSource> audioList = new List<AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            audio = GetComponent<AudioSource>();
            audio.playOnAwake = false;
            audio.loop = true;

            LoadSoundCheck();
            EffSoundAdd();
            
        }
        else if (instance != null)
        {
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(instance);
    }

    private void Start() => StartFunc();

    private void StartFunc()
    {

    }

    public void SoundBGM(string name)
    {
        AudioClip clip = FindSound(name);

        if (clip != null)
        {
            if (audio.clip == clip)
                return;

            audio.clip = clip;
            audio.volume = GlobalData.MainSound;
            audio.Play();
        }
    }

    public void SoundPlay(string name, bool loop = false)
    {
        if (audioList == null)
            return;

        AudioClip clip = FindSound(name);

        if (clip != null)
        {
            audioList[playSoundIdx].clip = clip;
            audioList[playSoundIdx].volume = GlobalData.MainSound;
            audioList[playSoundIdx].Play();

            playSoundIdx++;

            if (playSoundIdx < effSoundCount)
                playSoundIdx = 0;
        }
    }

    void EffSoundAdd()
    {
        for (int i = 0; i < effSoundCount; i++)
        {
            GameObject obj = new GameObject();
            obj.name = "EffSound";
            obj.transform.SetParent(transform, false);

            AudioSource audio = obj.AddComponent<AudioSource>();

            audioList.Add(audio);
        }
    }

    public void LoadSoundCheck()
    {
        AudioClip clip;

        object[] temps = Resources.LoadAll("Audio");

        for (int i = 0; i < temps.Length; i++)
        {
            clip = temps[i] as AudioClip;
            clipList.Add(clip.name, clip);
        }
    }

    AudioClip FindSound(string name)
    {
        string key = "";

        foreach (KeyValuePair<string, AudioClip> items in clipList)
        {
            if (items.Key.Contains(name))
            {
                key = items.Key;
                break;
            }
        }

        return clipList[key];
    }

    public void MuteVolumeCheck()
    {
        if (GlobalData.SoundCheck == false)
        {
            audio.volume = 0.0f;

            for (int i = 0; i < audioList.Count; i++)
            {
                audioList[i].volume = 0.0f;
            }
        }
        else
        {
            audio.volume = GlobalData.MainSound;

            for (int i = 0; i < audioList.Count; i++)
            {
                audioList[i].volume = GlobalData.MainSound;
            }
        }
    }
}
