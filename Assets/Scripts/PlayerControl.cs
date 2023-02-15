using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [Header("Inscribed")]

    public float yLimit = 7.5f;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = 10;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = startPos;

        pos.y = mousePos3D.y;

        pos.y = Mathf.Clamp(mousePos3D.y, -yLimit, yLimit);

        transform.position = pos;

    }
}
