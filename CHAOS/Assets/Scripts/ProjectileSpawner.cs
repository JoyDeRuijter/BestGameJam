using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles;

    private GameObject spawnedProjectile;

    [SerializeField]
    private Transform leftPos;
    private Transform rightPos;

    private int randomIndex;
    private int randomSide;

    //private Vector2 position;
    private float spawnTime = 1f;
    private float speed;
    // private int direction;

    private void Start()
    {
        StartCoroutine(SpawnLasers());
        speed = 5f;

    }

    IEnumerator SpawnLasers()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, projectiles.Length);
            randomSide = Random.Range(0, 2);

            spawnedProjectile = Instantiate(projectiles[randomIndex]);

            // Left
            if (randomSide == 0)
            {
                spawnedProjectile.transform.position = leftPos.position;
                spawnedProjectile.GetComponent<>().speed = Random.Range(4, 10);
            }
            // Right
            else
            {
                spawnedProjectile.transform.position = rightPos.position;
                spawnedProjectile.GetComponent<Laser>().speed = -Random.Range(4, 10);
                spawnedProjectile.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
    private void Update()
    {

    }

    private void Spawner()
    {
        GameObject laserClone = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        laserClone.velocity = transform.forward * speed;

    }

}

