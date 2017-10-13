using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonObject : MonoBehaviour {
    public GameObject go;
    public float spawnCount;
    private float spawnWait=0f;
    public float nextTime;
    float nowTime=0f;
    // Use this for initialization
    void Update () {
        nowTime += Time.deltaTime;
        if (nowTime > spawnWait)
        {
            nowTime = 0;
            spawnWait = nextTime;
            for (int x = 0; x < spawnCount; x++)
            {
                Instantiate(go, new Vector3(Random.Range(-6, 6), 0, 16), transform.rotation);
            }
        }
	}
	
}
