using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    private AudioSource AudioSource;

    public SpriteRenderer SpriteRenderer;

    public float Speed = 1f;

    private bool IsHit = false;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsHit)
            return;

        IsHit = true;

        AudioSource.Play();

        if (collision.CompareTag("PlayerLaser"))
        {
            ScoreManager.AddPoint();
            Destroy(collision.gameObject);
        }

        EnemyFactory.EnemyLeft--;

        Destroy(gameObject, 0.2f);
        SpriteRenderer.enabled = false;
    }
}
