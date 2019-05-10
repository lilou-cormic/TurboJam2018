using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    public Player Player;

    public Image Life1Image;

    public Image Life2Image;

    public Image Life3Image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Life1Image.gameObject.SetActive(Player.Health >= 1);
        Life2Image.gameObject.SetActive(Player.Health >= 2);
        Life3Image.gameObject.SetActive(Player.Health >= 3);
    }
}
