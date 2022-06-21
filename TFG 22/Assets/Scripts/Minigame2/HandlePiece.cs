using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePiece : MonoBehaviour
{
    public HandleSet currentSet;

    public Material hoverMat;
    public Material normalMat;

    public void OnHoverEnter()
    {
        this.GetComponent<MeshRenderer>().material = hoverMat;
    }

    public void OnHoverExit()
    {
        this.GetComponent<MeshRenderer>().material = normalMat;
    }
}
