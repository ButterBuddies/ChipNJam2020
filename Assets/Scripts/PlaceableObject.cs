using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    private bool inPlacementMode = true;
    private Vector2 mousePos;

    public void Update()
    {
        if (inPlacementMode)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
        }

    }

    public void Placed()
    {
        inPlacementMode = false;
    }
}
