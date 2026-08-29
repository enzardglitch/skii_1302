using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text levelText;

    [SerializeField] 
    private TMP_Text HpText;

    [SerializeField]
    private TMP_Text coinText;
    [SerializeField]
    private GameObject victoryText;
    [SerializeField]
    private GameObject deathText;

    public static UIManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    { 
        instance = this; 
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStat()
    {
        levelText.text = $"Level {GameManager.level}";
        coinText.text = $"Coins: {GameManager.coins}";
        HpText.text = $"Health: {GameManager.instance.player.GetComponent<Player>().HP}%";
    }

    public void ShowVictory(bool show)
    {
        if (show == false)
        {

            victoryText.SetActive(false);
            return;
        }

        victoryText.SetActive(true);

    }

    public void ShowDeath(bool show)
    {
        if (show == false)
        {

            deathText.SetActive(false);
            return;
        }

        deathText.SetActive(true);
    }

    public void ResetUI()
    {
        victoryText.SetActive(false);
        deathText.SetActive(false);
    }


}
