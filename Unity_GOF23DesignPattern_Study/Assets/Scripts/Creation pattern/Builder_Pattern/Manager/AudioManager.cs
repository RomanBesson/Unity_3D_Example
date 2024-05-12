using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager {

    private static AudioManager instance;
    public static AudioManager Instance()
    {
        if(instance == null)
        {
            instance = new AudioManager();
        }
        return instance;
    }

    private Dictionary<int, string> audioDic = null;

    private AudioManager()
    {
        audioDic = new Dictionary<int, string>();
        audioDic.Add(1, "mk1.mp3");
        audioDic.Add(2, "mk2.mp3");
        audioDic.Add(3, "mk3.mp3");
        audioDic.Add(4, "mk4.mp3");
    }

    public void SetAudios(Monster monster)
    {
        string tempAudio = null;
        audioDic.TryGetValue(monster.Id, out tempAudio);
        monster.Audios = tempAudio;
    }
}
