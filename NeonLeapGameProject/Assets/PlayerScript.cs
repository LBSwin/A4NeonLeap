using System.Security.Cryptography.X509Certificates;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float Health, MaxHealth;
    public GameManager gameManager;
    private bool isDead;

    [SerializeField]
    private HealthBarUI healthBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            SetHealth(-25f);
        }

        if (Input.GetKeyDown("h"))
        {
            SetHealth(25f);
        }

        if (Health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
        }

    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }
}
