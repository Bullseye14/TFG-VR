using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{
    public Material material;

    public int value = 0;

    void Start()
    {
        // At the beginning of the scene, each ball is assigned a value
        this.name = "Ball" + value;

        // Each ball is assigned with its corresponding material
        this.GetComponent<MeshRenderer>().material = material;
    }
}
