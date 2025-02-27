using UnityEngine;

public class PushDetector : MonoBehaviour
{
    private PushableBox parentBox;

    private void Start()
    {
        parentBox = GetComponentInParent<PushableBox>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parentBox.SetPushing(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parentBox.SetPushing(false);
        }
    }
}

