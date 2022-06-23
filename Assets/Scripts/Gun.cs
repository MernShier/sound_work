using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject firePoint, bullet, currentBullet, bulletStorage;
    [SerializeField] private AudioSource MainAudioSource; [SerializeField] private AudioClip fireSound;
    [SerializeField] private float x, z, speed, fireDelay, fireTimer, firePower;
    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().velocity = new Vector3(x * speed, 0 * speed, z * speed);
        fireTimer += Time.deltaTime;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && fireDelay <= fireTimer && Time.timeScale!=0)
        {
            GunFire();
        }
    }
    public void GunFire()
    {
        currentBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity, bulletStorage.transform);
        currentBullet.GetComponent<Rigidbody>().velocity = new Vector3(0,0,1)*firePower;
        MainAudioSource.PlayOneShot(fireSound);
        //Debug.Log(currentBullet.GetComponent<Rigidbody>());
        fireTimer = 0;
    }
}
