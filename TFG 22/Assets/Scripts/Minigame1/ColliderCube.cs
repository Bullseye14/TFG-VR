using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCube : MonoBehaviour
{
    public List<GameObject> numbers;

    public int number = -1;

    public bool numbered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "GreenBall")
        {
            // If the space contains a number, remove the number
            if (numbered)
            {
                foreach (Transform child in transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }

            // If it's the first hit, set numbered to true
            else
                numbered = true;

            // Instantiate the new number
            Instantiate(numbers[GetValue(collision.collider.name)], this.transform);
        }

    }

    private int GetValue(string value)
    {
        value = value.Replace("Ball", "");

        number = int.Parse(value);

        return int.Parse(value);
    }
}
