using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public void PlayMe(AudioClip par)
    {
        AudioSource.PlayClipAtPoint(par, transform.position);
    }
}
