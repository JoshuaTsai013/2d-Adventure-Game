using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Basic Parameter")]
    public float maxHealth;
    public float currentHealth;

    [Header("Invulnerable")]
    public float invulnerableDuration;
    private float invulnerableCounter;
    public bool isInvulnerable;



    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (isInvulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
            {
                isInvulnerable = false;
            }
        }
    }


    public void TakeDamage(Attack attacker)
    {
        //Debug.Log(attacker.damage);
        if (isInvulnerable)
            return;

        if (currentHealth - attacker.damage > 0)
        {
            currentHealth -= attacker.damage;
            TriggerInvulnerable();
        }
        else
        {
            currentHealth = 0;
            //Trigger Death
            Debug.Log("Play dead");
        }

    }
    private void TriggerInvulnerable()
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
