using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Spawner : MonoBehaviour
{
    private Collider spawnArea;
    public List<AudioClip> spawnSounds;

    public GameObject[] fruitPrefabs;
    public GameObject[] bombPrefabs;
    public GameObject[] specialPrefabs;

    [Range(0f, 1f)]
    public float badItemChance = 0.05f;

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;


    public float minZAngle = -15f;
    public float maxZAngle = -17f;

    public float minForce = 18f;
    public float maxForce = 22f;

    public float maxLifetime = 5f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    public void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);

        while (enabled)
        {
            GameObject prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

            if (Random.value < badItemChance) {
                if(Random.Range(0,2) == 0)
                {
                    prefab = bombPrefabs[Random.Range(0, bombPrefabs.Length)];
                }
                else
                {
                    prefab = specialPrefabs[Random.Range(0, specialPrefabs.Length)];
                }
            }

            Vector3 position = new Vector3
            {
                x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            };

            Quaternion rotation = Quaternion.Euler(transform.rotation.x, 0f, Random.Range(minZAngle, maxZAngle));

            GameObject fruit = Instantiate(prefab, position, rotation);

            GetComponent<AudioSource>().PlayOneShot(spawnSounds[Random.Range(0, 2)]);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

}