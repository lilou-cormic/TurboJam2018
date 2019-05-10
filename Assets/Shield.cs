using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Player Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.StartInvulerability();

        Destroy(collision.gameObject);
        EnemyFactory.EnemyLeft--;

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
