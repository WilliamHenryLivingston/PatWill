using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneTrigger : MonoBehaviour
{
    [SerializeField] private Collider boxCollider;
    [SerializeField] private HealthSystem playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.DecreaseHealth(100);
        }
    }
}
