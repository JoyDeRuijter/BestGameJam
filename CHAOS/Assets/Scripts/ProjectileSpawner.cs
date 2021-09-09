using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject laser;
    private int timer = 0;
    private int spawntime;

    // Start is called before the first frame update
    void Start()
    {
        spawntime = Random.Range(20, 300);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        if (timer == spawntime)
        {
            timer = 0;
            spawntime = Random.Range(20, 300);
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject laserInstance = Instantiate(laser, new Vector3(20, Random.Range(0, 5)),gameObject.GetComponent<Transform>().rotation);

        if (Random.Range(0,1.9f) > 1)
        {
            laserInstance.GetComponent<Laser>().speed.x *= -1;
            laserInstance.transform.SetPositionAndRotation(new Vector3(-20, Random.Range(0, 5)), gameObject.GetComponent<Transform>().rotation);
            laserInstance.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
