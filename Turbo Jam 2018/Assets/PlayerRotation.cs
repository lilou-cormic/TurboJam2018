using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Camera Camera;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var dir = transform.position - mousePos;

        rb.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
    }
}
