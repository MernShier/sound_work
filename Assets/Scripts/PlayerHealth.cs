using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int Health;
    private void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("RedEnemy"))
        {
            Health--;
            Destroy(other);
        }
    }
    private void FixedUpdate()
    {
        if (Health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        SceneManager.LoadScene(0);
    }
}
