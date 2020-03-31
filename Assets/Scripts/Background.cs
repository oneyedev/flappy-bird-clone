using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material material;
    public Vector2 offset;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset += Vector2.right * speed * Time.deltaTime;
        SetTextureOffset(offset);
    }

    private void OnDestroy()
    {
        SetTextureOffset(Vector2.zero);
    }

    void SetTextureOffset(Vector2 offset)
    {
        this.offset = offset;
        material.SetTextureOffset("_MainTex", offset);
    }
}
