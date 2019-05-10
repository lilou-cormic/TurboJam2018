using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public PlayerLaserFactory Factory;

    private float CoolDown = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused || GameOver.IsGameOver)
            return;

        if (CoolDown <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Factory.Shoot();

                CoolDown = 0.2f;
            }
        }
        else
        {
            CoolDown -= Time.deltaTime;
        }
    }
}
