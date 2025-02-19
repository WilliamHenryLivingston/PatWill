using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum StartPosition { Start, Middle, End }
    [SerializeField] private StartPosition startPosition = StartPosition.Start;
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private bool moveOnXAxis;
    [SerializeField] private bool moveOnYAxis;
    [SerializeField] private bool moveOnZAxis;
    [SerializeField] private float platformSpeed = 1;
    [SerializeField] private float distanceToMove;

    [SerializeField] private float pingpong;

    private float timeOffset; // Controls where in the pingpong cycle the movement starts


    private void Start()
    {
        startingPosition = transform.position;

        // Adjust time offset based on the selected start position
        switch (startPosition)
        {
            case StartPosition.Start:
                timeOffset = 0; // Start at the beginning (one end)
                break;
            case StartPosition.Middle:
                timeOffset = (distanceToMove / platformSpeed) / 2; // Start in the middle
                break;
            case StartPosition.End:
                timeOffset = distanceToMove / platformSpeed; // Start at the opposite end
                break;
        }
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        pingpong = Mathf.PingPong(Time.time * platformSpeed + timeOffset, distanceToMove);
        if (moveOnXAxis)
        {
            //moveOnYAxis = false;
            //moveOnZAxis = false;
            transform.position = new Vector3(startingPosition.x + pingpong, startingPosition.y, startingPosition.z);
        }
        
        else if (moveOnYAxis)
        {
            //moveOnXAxis = false;
            //moveOnZAxis = false;
            transform.position = new Vector3(startingPosition.x, startingPosition.y + pingpong, startingPosition.z);
        }
        
        else if (moveOnZAxis)
        {
            //moveOnXAxis = false;
            //moveOnYAxis = false;
            transform.position = new Vector3(startingPosition.x, startingPosition.y, startingPosition.z + pingpong);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Transform playerRoot = other.transform.root;
    //    if (playerRoot.CompareTag("Player"))
    //    {
    //        playerRoot.position += transform.position - transform.position;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Transform playerRoot = other.transform.root;
    //    if (playerRoot.CompareTag("Player"))
    //    {
    //        playerRoot.transform.SetParent(null);
    //    }
    //}
}
