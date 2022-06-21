using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleSet : MonoBehaviour
{
    public List<TextMeshPro> texts;
    public List<GameObject> pieces;

    // We store all the positions and the rotation of each piece in the set
    public List<Vector3> piecePositions;
    public Quaternion pieceRotation;

    private void Start()
    {
        piecePositions.Clear();

        for(int i = 0; i < pieces.Count; i++)
        {
            piecePositions.Add(pieces[i].transform.localPosition);
        }

        pieceRotation = pieces[0].transform.rotation;
    }

    public void AssignTexts(List<int> numbers)
    {
        for(int i = 0; i < texts.Count; i++)
        {
            texts[i].text = numbers[i].ToString();
        }
    }
}
