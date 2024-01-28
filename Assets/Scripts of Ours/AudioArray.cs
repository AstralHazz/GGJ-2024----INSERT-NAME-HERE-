using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private AudioClip myAudioClip1;
    [SerializeField] private AudioClip myAudioClip2;
    [SerializeField] private float volume = 0.5f;
    bool objHasRun = false;

    private void OnTriggerEnter(Collider other)
    {
        if (objHasRun != true)
        {

            if(other.gameObject.CompareTag("Player"))
                {
                if (!myAudioSource.isPlaying)
                {
                    myAudioSource.PlayOneShot(myAudioClip1, volume);
                    objHasRun = true;
                    //PLAYS ONCE
                }
                else
                {
                    myAudioSource.Stop();
                }
            }
        }
    }

}