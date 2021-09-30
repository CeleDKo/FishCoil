using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _close;
    [SerializeField] private PlaySounds _playSounds;
    [SerializeField] private DarkScreen _darkScreen;
    private void Start()
    {
        _play.onClick.AddListener(Play);
        _close.onClick.AddListener(CloseGame);
        Debug.LogWarning("Путь установки приложения - " + Application.persistentDataPath);
    }
    public void Play()
    {
        _playSounds.PlaySound(PlaySounds.SoundType.Click);
        StartCoroutine(_darkScreen.ChangeSceneOn(1));
    }
    public void CloseGame()
    {
        Application.Quit();
        _playSounds.PlaySound(PlaySounds.SoundType.Click);
    }
}