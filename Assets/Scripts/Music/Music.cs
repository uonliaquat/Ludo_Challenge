using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    public AudioSource musicSource;
    public static bool isMusicPlaying;
    private void Awake()
    {
        isMusicPlaying = true;
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        if (Database.GetMusicStatus() == "0" || Database.GetMusicStatus() == GameConstants.MUSIC_PLAYING_TRUE)
        {
            musicSource.Play();
            isMusicPlaying = true;
            Database.SetMusicStatus(GameConstants.MUSIC_PLAYING_TRUE);
        }
        else
        {
            isMusicPlaying = false;
            Database.SetMusicStatus(GameConstants.MUSIC_PLAYING_FALSE);
        }
    }
    private void Update()
    {
        if (isMusicPlaying)
        {
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
        else if (!isMusicPlaying)
        {
            if (musicSource.isPlaying)
            {
                musicSource.Stop();
            }
        }
    }


}
