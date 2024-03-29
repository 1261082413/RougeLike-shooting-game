using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource levelMusic,gameOverMusic,Winmusic;

    public AudioSource[] sfx;
    // Start is called before the first frame update
    private void awake()
    {
        instance = this;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();


    }
    public void Win(){
        levelMusic.Stop();
        Winmusic.Play();
    }
    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();

    }
}