using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startAudio, endAudio;
    public bool morte, ambos;
    public GameObject particle;
    void Start()
    {
        audioSource = FindObjectOfType<Camera>().GetComponent<AudioSource>();
        if(!morte || ambos)
            audioSource.PlayOneShot(startAudio);
    }

    private void OnDestroy()
    {
        if(morte || ambos)
            audioSource.PlayOneShot(endAudio);

        Instantiate(particle, transform.position, transform.rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }


}
