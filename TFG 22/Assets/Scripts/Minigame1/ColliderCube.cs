using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCube : MonoBehaviour
{
    public List<GameObject> numbers;

    public int number = -1;

    public bool numbered = false;

    public void PlaceNewNumber(int newNumber)
    {
        // If there was no number, set numbered to true
        if (!numbered)
            numbered = true;

        // Remove the previous number
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        number = newNumber;

        if (newNumber > -1)
            Instantiate(numbers[newNumber], this.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the ball touches a collider of the operation
        if (collision.collider.tag == "GreenBall")
            PlaceNewNumber(GetValue(collision.collider.name));

    }

    // Returns the value that the box has to take and change the number to that value
    private int GetValue(string value)
    {
        value = value.Replace("Ball", "");

        number = int.Parse(value);

        return int.Parse(value);
    }
}
