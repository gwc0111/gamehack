using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class BGMManager : MonoBehaviour
{
    [Tooltip("音乐")]
    public Sound[] sounds;
    [Tooltip("音效")]
    public Sound[] audioEffect;
    public static BGMManager instance;
    private AudioSource audioEffectSource;
    private AudioSource actionEffectSource;

    float globalBGM;
    float globalSound;

    bool isSetting;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        audioEffectSource = gameObject.AddComponent<AudioSource>();
        actionEffectSource = gameObject.AddComponent<AudioSource>();
    }

    public void Start()
    {
        if(!PlayerPrefs.HasKey("BGM"))
        {
            globalBGM = 1;
            PlayerPrefs.SetFloat("BGM", globalBGM);
        }
        if (!PlayerPrefs.HasKey("Sound"))
        {
            globalSound = 1;
            PlayerPrefs.SetFloat("Sound", globalSound);
        }
        globalBGM = PlayerPrefs.GetFloat("BGM");
        globalSound = PlayerPrefs.GetFloat("Sound");
        isSetting = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!isSetting)
            return;

        globalBGM = PlayerPrefs.GetFloat("BGM");
        globalSound = PlayerPrefs.GetFloat("Sound");

        //更新正在播放的曲子的音量
        for (int i = 0; i < sounds.Length; ++i)
        {
            if (sounds[i].source.isPlaying)
            {
                sounds[i].source.volume = sounds[i].volume * globalBGM;
            }
        }
    }

    public void SetVolumeChanging(bool isChanging)
    {
        isSetting = isChanging;
    }

    public void PauseBGM(float fadeTime = 0f)
    {
        StartCoroutine(AsynPauseBGM(fadeTime));
    }

    public void PauseBGM(string name, float fadeTime = 0f)
    {
        StartCoroutine(AsynPauseBGM(fadeTime, name));
    }

    IEnumerator AsynPauseBGM(float fade, string name = "")
    {
        for (int i = 0; i < sounds.Length; ++i)
        {
            if (sounds[i].source.isPlaying)
            {
                if (name != "")
                {
                    if (sounds[i].name != name)
                        continue;
                }

                sounds[i].source.DOFade(0, fade);

                yield return new WaitForSeconds(fade);

                sounds[i].source.Pause();
            }
        }
    }

    public void PlayBGM(string name, float fadeTime = 0)
    {
        //暂停其他BGM
        for (int i=0;i<sounds.Length;++i)
        {
            if(sounds[i].source.isPlaying)
            {
                if (sounds[i].name == name)
                    return;     //如果当前正在播放的BGM和即将播放的是同一个，则返回
                else if (sounds[i].name == "Sleep")   //睡觉的音乐需要完全停止
                    sounds[i].source.Stop();
                else
                    sounds[i].source.Pause();
            }
        }

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("BGM " + name + " not found!");
            return;
        }
        if (fadeTime == 0)
        {
            s.source.volume = s.volume * globalBGM;
            s.source.Play();
        }
        else
        {
            s.source.volume = 0;
            s.source.Play();
            s.source.DOFade(s.volume * globalBGM, fadeTime);
        }
    }

    public void PlayBGMWithoutStop(string name, float fadeTime = 0)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("BGM " + name + " not found!");
            return;
        }
        if (fadeTime == 0)
        {
            s.source.volume = s.volume * globalBGM;
            s.source.Play();
        }
        else
        {
            s.source.volume = 0;
            s.source.Play();
            s.source.DOFade(s.volume * globalBGM, fadeTime);
        }
    }


    public void PlayAudioEffect(string name, float delay = 0f)
    {
        Sound s = Array.Find(audioEffect, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio Effect " + name + " not found!");
            return;
        }
        Debug.Log("PlayAudioEffect " + name);

        audioEffectSource.volume = s.volume * globalSound;
        audioEffectSource.loop = s.loop;
        StartCoroutine(ASynPlayAudioEffect(audioEffectSource, s.clip, delay));
    }

    public void PlayAudioEffect(Sound sound, float delay = 0f)
    {
        audioEffectSource.volume = sound.volume * globalSound;
        audioEffectSource.loop = sound.loop;
        StartCoroutine(ASynPlayAudioEffect(audioEffectSource, sound.clip, delay));
    }

    IEnumerator ASynPlayAudioEffect(AudioSource source, AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (clip != null) 
            source.PlayOneShot(clip);
    }

    public float GetBGMLength(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return 0;
        }

        return s.clip.length;
    }

    public void StopActionEffect()
    {
        actionEffectSource.Stop();
    }

    public float GetSleepEffectVolume()
    {
        Sound s = Array.Find(audioEffect, sound => sound.name == "Duagi");
        return s.volume * globalSound;
    }
}
