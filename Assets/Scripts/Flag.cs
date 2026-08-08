using UnityEngine;

public class Flag : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        player.Point += 10;

        UIManager.instance.ShowNotiText($"+10 points\nPoints: {player.Point}");
        Destroy(gameObject);
    }
}
