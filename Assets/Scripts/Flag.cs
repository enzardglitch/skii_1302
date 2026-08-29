using UnityEngine;

public class Flag : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private int point;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player == null)
        {
            return;
        }
        GameManager.instance.TakeCoin(player, point);
        AudioManager.instance.PlaySFX(0);
        gameObject.SetActive(false);
    }
}
