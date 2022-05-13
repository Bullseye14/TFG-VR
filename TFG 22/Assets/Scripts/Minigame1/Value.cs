using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{
    public List<Material> materials;

    public int value = 0;
    // Start is called before the first frame update

    void Start()
    {
        this.name = "Ball" + value;

        this.GetComponent<MeshRenderer>().material = materials[value];
    }
}
