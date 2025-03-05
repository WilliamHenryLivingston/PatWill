using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Canvas gameOverScreen;
    [SerializeField] private Canvas playerHUD;

    //public static UIManager Instance { get; private set; }

    private void Awake()
    {
        //if (Instance != null && Instance !=this)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //Instance = this;
        //DontDestroyOnLoad(gameObject);

        gameOverScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
        HealthBar();
    }

    private void HealthBar()
    {
        float currentHealth = healthSystem.GetCurrentHealth();
        healthText.text = "Health: " + currentHealth.ToString("F0");
        healthSlider.value = currentHealth;
        fillImage.color = Color.Lerp(Color.red, Color.green, healthSlider.value / 100);
    }

    public void PlayGameOverScreen()
    {

        gameOverScreen.gameObject.SetActive(true);
    }
}
