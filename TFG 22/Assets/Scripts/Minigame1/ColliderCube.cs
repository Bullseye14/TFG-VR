using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCube : MonoBehaviour
{
    public GameObject digit; 

    public List<GameObject> numbers;

    public int number = -1;

    public bool numbered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "GreenBall" && !numbered)
        {
            digit = Instantiate(numbers[GetValue(collision.collider.name)], digit.transform);

            numbered = true;

            collision.collider.gameObject.SetActive(false);
        }
    }

    private int GetValue(string value)
    {
        value = value.Replace("Ball", "");

        number = int.Parse(value);

        return int.Parse(value);
    }
}
