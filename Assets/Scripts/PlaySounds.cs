using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> sounds;
    private AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.mute = PlayerPrefs.GetString("Sound", "On") == "On";
    }
    public void PlaySound(SoundType type)
    {
        source.PlayOneShot(sounds[GetSoundTypeNumber(type)]);
    }
    private int GetSoundTypeNumber(SoundType type) => (int)type;
    public enum SoundType
    {
        Click,
        TakeBonus,
        Damage,
        PopBubble,
        TakeScore
    }
}
