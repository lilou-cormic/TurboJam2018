using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private AudioSource AudioSource;

    public SpriteRenderer InvulnerabilitySpriteRenderer;

    public SpriteRenderer Damage1SpriteRenderer;
    public SpriteRenderer Damage2SpriteRenderer;
    public SpriteRenderer Damage3SpriteRenderer;

    private int MaxHealth = 3;
    public int Health { get; private set; }

    private float invulnerableTime = 1f;
    private float invulnerableTimeLeft = 0f;

    public static event Action PlayerDeath;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

        ScoreManager.NewWave += ScoreManager_NewWave;
        Health = MaxHealth;

        InvulnerabilitySpriteRenderer.enabled = false;
        Damage1SpriteRenderer.enabled = false;
        Damage2SpriteRenderer.enabled = false;
        Damage3SpriteRenderer.enabled = false;
    }

    private void Start()
    {
        ScoreManager.Reset();
    }

    private void OnDestroy()
    {
        ScoreManager.NewWave -= ScoreManager_NewWave;
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnerableTimeLeft > 0)
        {
            InvulnerabilitySpriteRenderer.enabled = !InvulnerabilitySpriteRenderer.enabled;

            invulnerableTimeLeft -= Time.deltaTime;

            if (invulnerableTimeLeft <= 0)
                invulnerableTimeLeft = 0;
        }
        else
        {
            InvulnerabilitySpriteRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (invulnerableTimeLeft > 0)
            return;

        AudioSource.Play();
        Health--;

        Damage1SpriteRenderer.enabled = false;
        Damage2SpriteRenderer.enabled = Health == 2;
        Damage3SpriteRenderer.enabled = Health == 1;

        if (Health <= 0)
        {
            PlayerDeath?.Invoke();
        }
        else
        {
            StartInvulerability();
        }
    }

    public void StartInvulerability()
    {
        invulnerableTimeLeft = invulnerableTime;
    }

    private void ScoreManager_NewWave()
    {
        invulnerableTimeLeft = 0;
        Health = MaxHealth;
        InvulnerabilitySpriteRenderer.enabled = false;
        Damage1SpriteRenderer.enabled = false;
        Damage2SpriteRenderer.enabled = false;
        Damage3SpriteRenderer.enabled = false;
    }
}
