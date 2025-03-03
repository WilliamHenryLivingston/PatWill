using UnityEngine;

public class EndGameScenario : MonoBehaviour
{
    public AudioSource audioSource; 

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            if (audioSource != null)
            {
                audioSource.Play(); 
            }
        }
    }
}