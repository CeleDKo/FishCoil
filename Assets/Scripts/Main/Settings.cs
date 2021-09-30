using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button _sound;
    [SerializeField] private Button _music;
    [SerializeField] PlaySounds _playSounds;
    private bool _soundOn;
    private bool _musicOn;
    private void Start()
    {
        _sound.onClick.AddListener(SwitchSounds);
        _music.onClick.AddListener(SwitchMusic);

        if (PlayerPrefs.GetString("Sound", "On") == "On")
            EnableSound();
        else
            DisableSound();

        if (PlayerPrefs.GetString("Music", "On") == "On")
            EnableMusic();
        else
            DisableMusic();
    }
    public void SwitchSounds()
    {
        _soundOn = !_soundOn;
        if (_soundOn) EnableSound();
        else DisableSound();
        _playSounds.PlaySound(PlaySounds.SoundType.Click);
    }
    private void EnableSound()
    {
        _soundOn = true;
        _playSounds.gameObject.GetComponent<AudioSource>().mute = true;
        _sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("SoundOff");
        PlayerPrefs.SetString("Sound", "On");
    }

    private void DisableSound()
    {
        _soundOn = false;
        _playSounds.gameObject.GetComponent<AudioSource>().mute = false;
        _sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("SoundOn");
        PlayerPrefs.SetString("Sound", "Off");
    }
    public void SwitchMusic()
    {
        _musicOn = !_musicOn;
        if (_musicOn) EnableMusic();
        else DisableMusic();
        _playSounds.PlaySound(PlaySounds.SoundType.Click);
    }
    private void EnableMusic()
    {
        _musicOn = true;
        _music.GetComponent<Image>().sprite = Resources.Load<Sprite>("MusicOff");
        PlayerPrefs.SetString("Music", "On");
    }

    private void DisableMusic()
    {
        _musicOn = false;
        _music.GetComponent<Image>().sprite = Resources.Load<Sprite>("MusicOn");
        PlayerPrefs.SetString("Music", "Off");
    }
}