using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneEyed.Utils
{
    public class Spawner : MonoBehaviour
    {
        public GameObject prefab;
        public Transform root;

        void Start()
        {

        }

        void Update()
        {

        }


        public void SpawnTo(GameObject target)
        {
            var clone = Instantiate(prefab, target.transform.position, Quaternion.identity, root);
            clone.SetActive(true);
        }
    }
}

