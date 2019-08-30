using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] points;
    public float[] ChanceToSpawn;
    public bool w8;
    public float SpawnParametrsX;
    public float SpawnParametrsY;
    // Start is called before the first frame update
    void Start()
    {
        w8 = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartSpawn();
    }
    void StartSpawn()
    {
        if (w8)
        {
            w8 = false;
            Invoke("ChangeW", 1);
            for (int i = 0; i < points.Length; i++)
            {
                Vector3 Position = new Vector3
                    (Random.Range(-SpawnParametrsX, SpawnParametrsX) + transform.position.x,
                    Random.Range(-SpawnParametrsY, SpawnParametrsY) + transform.position.y, 0);
                if (ChanceToSpawn[i] > Random.Range(0, 100))
                {
                    Instantiate(points[i], Position, Quaternion.identity);
                }
            }
        }
    }
    void ChangeW()
    {
        w8 = true;
    }
}
