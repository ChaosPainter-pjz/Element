using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class buttonsound : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public void click()
    {
        source.PlayOneShot(clip);
    }
}
