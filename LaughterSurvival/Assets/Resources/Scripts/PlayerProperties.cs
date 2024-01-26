using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [Range(0f, 100f)]
    public float playerHealth = 100f;
    private bool movementEnabled;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerDeath()
    {
        //TODO
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<EnemyBase>().onAttackSuccess();
        if (other.gameObject.transform.parent.name == "Zombie")
        {
            StartCoroutine(DisableMovementForSeconds(1f));
        }
    }

    IEnumerator DisableMovementForSeconds(float seconds)
    {
        GlobalGameManager.Instance.Player.Controller.movementEnabled = false;

        yield return new WaitForSeconds(seconds);

        GlobalGameManager.Instance.Player.Controller.movementEnabled = true;
    }

    //IEnumerator PlayerInvincibleForSeconds(float seconds)
    //{
    //    //TODO
    //}
}
