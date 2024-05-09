using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEffectManager : MonoBehaviour
{
    private ParticleSystem[] particleSystems;

    void Awake()
    {
        particleSystems = transform.GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        PlayEffects();
    }

    public void PlayEffects()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Play();
        }
    }
}
