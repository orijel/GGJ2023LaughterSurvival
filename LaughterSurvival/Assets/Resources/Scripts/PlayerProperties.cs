using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [Range(0f, 100f)]
    public float playerHealth = 100f;
    public bool playerDamageable = true;
    private bool movementEnabled;
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
        //TODO
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
                if (enemy.transform.name == "Zombie")
                {
                    StartCoroutine(DisableMovementForSeconds(1f));
                    StartCoroutine(PlayerInvincibleForSeconds(2f));
                    playerHealth -= 10f;
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
