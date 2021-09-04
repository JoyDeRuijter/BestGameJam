using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject deathScreen;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.collider.tag == "laser")
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("hit");
        gameObject.GetComponent<AudioSource>().Play();
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
