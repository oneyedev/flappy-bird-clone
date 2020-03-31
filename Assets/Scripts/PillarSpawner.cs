using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneEyed.Events;

public class PillarSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform root;
    public GameObject lastClone;
    public float timeInterval, distance;
    public float time;
    public List<float> levels;
    public int index;

    void Start()
    {

    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            index++;
            Spawn();
            time = timeInterval;
        }
    }

    private void Spawn()
    {
        float y = index < levels.Count ? levels[index] : Random.Range(-10f, 15f);
        var position = new Vector3(lastClone.transform.position.x + distance, y, lastClone.transform.position.z);
        lastClone = Instantiate(prefab, position, Quaternion.identity, root);
    }
}
