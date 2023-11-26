using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip clip;
    public void Start()
    {
        toPlayMaster(clip);
    }

    public void toPlayMaster(AudioClip _clip)
    {
        SoundManager.Instance.SetBGM(_clip);
        SoundManager.Instance.PlayBGM();
    }

    public void toStopMaster()
    {
        SoundManager.Instance.StopBGM();
    }

}
