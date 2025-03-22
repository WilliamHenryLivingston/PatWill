using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }


    }
   
    public void PlaySound(AudioSource audioSource)
    {
        audioSource?.Play();
    }

    public void StopSound(AudioSource audioSource)
    { 
        audioSource?.Stop();
    }

}
