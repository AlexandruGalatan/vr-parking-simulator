using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpaqueEffect : MonoBehaviour
{
    public float oscillationSpeed = 1f;
    public float minAlpha = 0f;
    public float maxAlpha = 1f;

    private Material objectMaterial;
    private float startTime;

    void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;

        startTime = Time.time;
    }

    void Update()
    {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.Sin((Time.time - startTime) * oscillationSpeed));

        Color materialColor = objectMaterial.color;
        materialColor.a = alpha;
        objectMaterial.color = materialColor;
    }
}
