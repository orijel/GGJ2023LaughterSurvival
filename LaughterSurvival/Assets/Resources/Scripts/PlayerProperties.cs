using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProperties : MonoBehaviour
{
    [Range(0f, 100f)]
    public float playerHealth = 100f;
    public bool playerDamageable = true;
    private bool movementEnabled;
    [SerializeField] private UnityEvent onDeath;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        onDeath.Invoke();
    }


    private void OnTriggerStay(Collider other)
    {
        EnemyBase enemy = other.GetComponentInParent<EnemyBase>();
        if (enemy != null)
        {
            enemy.onAttack();
            if (playerDamageable)
            {
                enemy.onAttackSuccess();

                // IF THE ATTACK IS A ZOMBIE:
                if (enemy.tag == "Enemy")
                {
                    StartCoroutine(DisableMovementForSeconds(1f));
                    StartCoroutine(PlayerInvincibleForSeconds(2f));
                    playerHealth -= enemy.Damage;
                }
            }
        }
    }

    IEnumerator DisableMovementForSeconds(float seconds)
    {
        GlobalGameManager.Instance.Player.Controller.movementEnabled = false;

        yield return new WaitForSeconds(seconds);

        GlobalGameManager.Instance.Player.Controller.movementEnabled = true;
    }

    IEnumerator PlayerInvincibleForSeconds(float seconds)
    {
        playerDamageable = false;

        yield return new WaitForSeconds(seconds);

        playerDamageable = true;
    }
}
