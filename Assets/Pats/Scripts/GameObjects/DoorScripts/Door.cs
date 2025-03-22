using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Assign onto the door itself.
    [SerializeField] private PhysicalButton doorButton;
    [SerializeField] private Vector3 openOffset;
    [SerializeField] private float doorSpeed;
    [SerializeField] private AudioSource doorSound;
    private Vector3 closedPosition;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        closedPosition = transform.position;

        if (doorButton != null) doorButton.OnPressed.AddListener(OpenDoor);
        doorSound.loop = false;
    }

    private void Update()
    {
        if (isOpen)
        {
            Vector3 targetPosition = closedPosition + openOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * doorSpeed);

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * doorSpeed);

        }
    }
    public void OpenDoor()
    {
        isOpen = true;
        if (!doorSound.isPlaying)
        {
            SoundManager.instance.PlaySound(doorSound);
        }
    }

    public void CloseDoor()
    {
        isOpen = false;
        if (!doorSound.isPlaying)
        {
            SoundManager.instance.PlaySound(doorSound);
        }
    }
}