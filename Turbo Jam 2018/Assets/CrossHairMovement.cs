using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairMovement : MonoBehaviour
{
    Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused || GameOver.IsGameOver)
        {
            Cursor.visible = true;
            return;
        }

        var mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;

        Cursor.visible = mousePos.magnitude > 7f;

    }
}
