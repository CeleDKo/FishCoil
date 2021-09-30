using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _sandBumping;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_sandBumping.isPlaying)
            _sandBumping.Play();
    }
}
