using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserFactory : MonoBehaviour
{
    public GameObject PlayerLaserPrefab;

    public void Shoot()
    {
        var laser = Instantiate(PlayerLaserPrefab, transform.position, transform.rotation);
        laser.GetComponent<Rigidbody2D>().velocity = laser.transform.up * 5f;
        Destroy(laser.gameObject, 5f);
    }
}
