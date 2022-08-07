using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject gameObject;
    private GameObject enemy;
    public MeshCollider plane;

    public float startDelay;
    public float spawnInterval;
    private float enemyCount;

    bool freezeAction;
    public AudioSource mySound;
    public AudioClip freezeSound;

    float x, z;

    Vector3 SpawnPosition;
    Vector3 sizeSpawnCollider = new Vector3(1f, 0.5f, 1f);

    public Collider[] colliders;
    bool checkCollider;

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(SpawnIntervalDecrease());
        InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);
    }

    void SpawnEnemies()
    {
        x = Random.Range(plane.transform.position.x - Random.Range(0, plane.bounds.extents.x), plane.transform.position.x + Random.Range(0, plane.bounds.extents.x));
        z = Random.Range(plane.transform.position.z - Random.Range(0, plane.bounds.extents.z), plane.transform.position.z + Random.Range(0, plane.bounds.extents.z));

        SpawnPosition = new Vector3(x, 0.5f, z);

        checkCollider = CheckSpawnPoint(SpawnPosition);
        if (checkCollider)
        {
            enemy = Instantiate(gameObject, SpawnPosition, Quaternion.identity);
            enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            enemy.name = "Enemy" + enemyCount;
            enemyCount += 1;

        }
        else
        {
            SpawnEnemies();
        }
    }

    bool CheckSpawnPoint(Vector3 spawnPosition)
    {
        colliders = Physics.OverlapBox(spawnPosition, sizeSpawnCollider);
        if(colliders.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private IEnumerator SpawnIntervalDecrease()
    {
        yield return new WaitForSeconds(20);

        CancelInvoke("SpawnEnemies");

        if (spawnInterval >= 3)
        {
            spawnInterval -= 1;
            StartCoroutine(SpawnIntervalDecrease());
        }

        if (!freezeAction)
        {
            InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);
        }
    }

    public void FreezeSpawn()
    {
        CancelInvoke("SpawnEnemies");
        mySound.PlayOneShot(freezeSound);
        freezeAction = true;

    }

    public void FreezeSpawnEnd()
    {
        InvokeRepeating("SpawnEnemies", startDelay, spawnInterval);
        freezeAction = false;
    }
}
