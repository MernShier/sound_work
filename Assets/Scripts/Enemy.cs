using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private GameObject deathParticle, Manager;
    [SerializeField] private AudioSource audioSourse;
    [SerializeField] private AudioClip audioClipDeath;
    private void Awake()
    {
        audioSourse = GameObject.FindGameObjectWithTag("MainAudioSourse").GetComponent<AudioSource>();
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-1 * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Gun") || collision.transform.CompareTag("Bullet"))
        {
            if (collision.transform.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
            }
            Manager.GetComponent<AudioVolumeController>().backGroundDistortion();
            audioSourse.PlayOneShot(audioClipDeath);
            Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }
}   