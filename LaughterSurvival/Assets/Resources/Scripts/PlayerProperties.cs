using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] public float playerHealth = 100f;
    [SerializeField] public float maximumHealth = 100;

    public bool playerDamageable = true;
    private bool movementEnabled;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private UnityEvent _onHealthUpdated;

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
        SceneManager.LoadScene(3);
    }


    private void OnTriggerStay(Collider other)
    {
        EnemyBase enemy = other.GetComponentInParent<EnemyBase>();
        if (enemy == null)
        {
            return;
        }

        if (!enemy.CanAttack)
        {
            return;
        }
        enemy.onAttack();

        if (playerDamageable)
        {
            enemy.OnAttackSuccess();

            // IF THE ATTACK IS A ZOMBIE:
            if (enemy.tag == "Enemy")
            {
                StartCoroutine(DisableMovementForSeconds(1f));
                StartCoroutine(PlayerInvincibleForSeconds(2f));
                playerHealth -= enemy.Damage;
                _onHealthUpdated.Invoke();
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
