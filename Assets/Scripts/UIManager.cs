using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text notiText;

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

    public void ShowNotiText(string s)
    {
        notiText.text = s;
    }
}
