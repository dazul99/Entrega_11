using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private Sprite[] sprites;

    private int number = 0;

    private bool paused = false;
    private bool stopped = false;
    private bool loop = false;
    private bool rand = false;

    private bool started = false;

    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (!started)
        {
            started = true;
            uiManager.SetTime(audioClips[number].length);
            uiManager.WriteName(audioClips[number].name, sprites[number]);
        }
        uiManager.ShowPause();
        paused = false;
        stopped = false;
        if (stopped)
        {
            audioSource.Play();
        }
        else if (paused)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.clip = audioClips[number];
            audioSource.Play();
        }
    }

    public void Pause()
    {
        uiManager.ShowPlay();
        paused = true;
        audioSource.Pause();
    }

    public void Stop()
    {
        uiManager.ShowPlay();
        stopped = true;
        audioSource.Stop();
    }

    public void Next()
    {
        if (rand)
        {
            number = Random.Range(0, audioClips.Length);
        }
        else if (!loop)
        {
            number++;
            if (number >= audioClips.Length) number = 0;
        }
        Play();
        uiManager.SetTime(audioClips[number].length);
        uiManager.WriteName(audioClips[number].name, sprites[number]);
        uiManager.ShowPause();
    }
    public void Previous()
    {
        if (rand)
        {
            number = Random.Range(0, audioClips.Length);
        }
        else if (!loop)
        {
            number--;
            if (number < 0) number = audioClips.Length - 1;
        }
        Play();
        uiManager.SetTime(audioClips[number].length);
        uiManager.WriteName(audioClips[number].name, sprites[number]);
        uiManager.ShowPause();
    }

    public void Rand()
    {
        rand = !rand;
    }
    public void Loop()
    {
        loop = !loop;
    }

    public void ChangeTime(float x)
    {
        audioSource.time = x;
    }

    private void Update()
    {
        uiManager.UpdateTime(audioSource.time);
        if (started)
        {
            if (audioSource.time == audioSource.clip.length)
            {
                Next();
            }
        }
        
    }
}
