using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    private AudioClip audio;

    public void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(audio, Vector3.zero);
    }

    public void LoadAudio()
    {
        audio = Resources.Load<AudioClip>(SetAudioPath());
    }

    public abstract string SetAudioPath();

	void Start () {
        LoadAudio();
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudio();
        }

	}
}
