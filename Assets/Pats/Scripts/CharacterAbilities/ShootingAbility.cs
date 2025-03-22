using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;
    [SerializeField] private AudioSource shootingSound;

    ObjectPooling objectPoolCache;

    private void Awake()
    {
        objectPoolCache = FindObjectOfType<ObjectPooling>();
        shootingSound.loop = false;
    }

    public void UnlockAbolity()
    {
        //i can work here
    }

    public void Shoot()
    {
        SoundManager.instance.PlaySound(shootingSound);
        Rigidbody clonedRigidbody = objectPoolCache.RetrieveAvailableBullet().GetRigidbody();
        if (clonedRigidbody == null)
        { 
            return;
        }
        clonedRigidbody.position = weaponTip.position;
        clonedRigidbody.rotation = weaponTip.rotation;

        //Rigidbody clonedRigidbody = Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
        clonedRigidbody.AddForce(weaponTip.forward * shootingForce);
        //Destroy(clonedRigidbody.gameObject,2);
        
    }
}
