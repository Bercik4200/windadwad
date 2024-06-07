using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    public void Spawn()
    {
        int randomize = Random.Range(0, obstacles.Count);
        Instantiate(obstacles[randomize]);
    }
    IEnumerator WaitForSpawn()
    {
        Spawn();
        yield return new WaitForSeconds(3f);
        StartCoroutine("WaitForSpawn");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitForSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}