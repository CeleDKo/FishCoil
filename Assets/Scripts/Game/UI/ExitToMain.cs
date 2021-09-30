using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMain : MonoBehaviour
{
    [SerializeField] private DarkScreen _darkScreen;
    [SerializeField] PlaySounds _playSounds;
    public void Exit()
    {
        _playSounds.PlaySound(PlaySounds.SoundType.Click);
        StartCoroutine(_darkScreen.ChangeSceneOn(0));
    }
}