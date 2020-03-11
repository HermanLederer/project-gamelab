﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    [SerializeField] private AudioClip SFX;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AudioManager.Instance.PlaySfx(SFX, 1);

        if (Input.GetKeyDown(KeyCode.W))
            AudioManager.Instance.PlayMusic(music1);

        if (Input.GetKeyUp(KeyCode.W))
            AudioManager.Instance.StopMusic(music1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            AudioManager.Instance.PlayMusic(music2);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            AudioManager.Instance.PlayMusicWithFade(music1);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            AudioManager.Instance.PlayMusicWithFade(music2);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            AudioManager.Instance.PlayMusicWithCrossFade(music1, 3.0f);

        if (Input.GetKeyDown(KeyCode.Alpha7))
            AudioManager.Instance.PlayMusicWithCrossFade(music2, 3.0f);
    }
}