using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource audioSourcePrefab;
    [SerializeField] private AudioSource audioSourceLoopPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void PlaySoundEffect(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(audioSourcePrefab, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    public AudioSource PlayLoopingSoundEffect(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(audioSourceLoopPrefab, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.loop = true;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        //Destroy(audioSource.gameObject, clipLength);

        return audioSource;
    }



}
