﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Image black_screen;
    [SerializeField]
    RectTransform game_title;
    [SerializeField]
    RectTransform play_btn;
    [SerializeField]
    RectTransform howtoplay_btn;
    //How to play ui elements
    [SerializeField]
    RectTransform howtoplay_title;
    [SerializeField]
    RectTransform tip_0;
    [SerializeField]
    RectTransform tip_1;
    [SerializeField]
    RectTransform tip_2;
    [SerializeField]
    RectTransform howtoplay_back_btn;
    //Play ui elements
    [SerializeField]
    RectTransform chooselevel_title;
    [SerializeField]
    RectTransform[] levels;
    [SerializeField]
    RectTransform play_back_btn;
    [SerializeField]
    AudioSource audio_source;
    [SerializeField]
    AudioClip button_pressed_fx;

    private void Start()
    {
        audio_source = GetComponent<AudioSource>();
        FadeBlackScreen();
    }

    public void FadeBlackScreen()
    {
        IEnumerator FadeBlackScreen()
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                black_screen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }

        StartCoroutine(FadeBlackScreen());
    }

    public void AppearBlackScreen()
    {
        IEnumerator AppearBlackScreen()
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                black_screen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        StartCoroutine(AppearBlackScreen());
    }

    public void LoadLevel(int level)
    {
        IEnumerator Delay()
        {
            AppearBlackScreen();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(level);
        }
        StartCoroutine(Delay());
    }

    public void PlayBtnClick()
    {
        PlayButtonPressedSound();
        DisappearMainMenu();
        AppearPlay();
    }

    public void PlayBackToMenuClick()
    {
        PlayButtonPressedSound();
        DisappearPlay();
    }

    public void HowToPlayBtnClick()
    {
        PlayButtonPressedSound();
        DisappearMainMenu();
        AppearHowToPlay();
    }

    public void HowToPlayBackToMenuClick()
    {
        PlayButtonPressedSound();
        DisappearHowToPlay();
    }

    public void DisappearMainMenu()
    {
        play_btn.GetComponent<Button>().enabled = false;
        howtoplay_btn.GetComponent<Button>().enabled = false;
        LeanTween.moveX(game_title, -1000f, 0.25f);
        LeanTween.moveX(play_btn, 1000f, 0.25f);
        LeanTween.moveX(howtoplay_btn, 1000f, 0.25f);
    }

    public void AppearMainMenu()
    {
        IEnumerator Delay()
        {
            LeanTween.moveX(game_title, 0f, 0.25f);
            LeanTween.moveX(play_btn, 0, 0.25f);
            LeanTween.moveX(howtoplay_btn, 0, 0.25f);
            yield return new WaitForSeconds(0.25f);
            play_btn.GetComponent<Button>().enabled = true;
            howtoplay_btn.GetComponent<Button>().enabled = true;
        }
        StartCoroutine(Delay());
    }

    public void AppearHowToPlay()
    {
        IEnumerator Delay()
        {
            LeanTween.moveY(howtoplay_title, 0, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(tip_0, 0, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(tip_1, 0, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(tip_2, 0, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(howtoplay_back_btn, 0, 0.25f);
            yield return new WaitForSeconds(0.25f);
            howtoplay_back_btn.GetComponent<Button>().enabled = true;
        }
        StartCoroutine(Delay());
    }

    public void DisappearHowToPlay()
    {
        IEnumerator Delay()
        {
            howtoplay_back_btn.GetComponent<Button>().enabled = false;
            LeanTween.moveY(howtoplay_back_btn, -1000, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(tip_2, -1000, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(tip_1, -1000, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(tip_0, -1000, 0.25f);
            yield return new WaitForSeconds(0.25f);
            LeanTween.moveY(howtoplay_title, 300, 0.25f);
            yield return new WaitForSeconds(0.25f);
            AppearMainMenu();
        }
        StartCoroutine(Delay());
    }

    public void AppearPlay()
    {
        IEnumerator Delay()
        {
            LeanTween.moveY(chooselevel_title, 0, 0.25f);
            for(int i=0; i<levels.Length; i++)
            {
                LeanTween.moveY(levels[i], 0, 0.25f);
                yield return new WaitForSeconds(0.1f);
            }
            LeanTween.moveY(play_back_btn, 0, 0.25f);
            yield return new WaitForSeconds(0.25f);
            play_back_btn.GetComponent<Button>().enabled = true;
        }
        StartCoroutine(Delay());
    }

    public void DisappearPlay()
    {
        IEnumerator Delay()
        {
            play_back_btn.GetComponent<Button>().enabled = false;
            LeanTween.moveY(play_back_btn, -1000, 0.25f);
            for (int i = 0; i < levels.Length; i++)
            {
                LeanTween.moveY(levels[i], -1000f, 0.25f);
                yield return new WaitForSeconds(0.1f);
            }
            LeanTween.moveY(chooselevel_title, 300, 0.25f);
            yield return new WaitForSeconds(0.25f);
            AppearMainMenu();
        }
        StartCoroutine(Delay());
    }

    public void PlayButtonPressedSound()
    {
        audio_source.clip = button_pressed_fx;
        audio_source.Play();
    }
}
