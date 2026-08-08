using UnityEngine;

public class Tree : MonoBehaviour
{

    private MeshRenderer rd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rd.material.color = Color.red;

        Player player = collision.gameObject.GetComponent<Player>();

        if (player == null)
        {
            return;
        }
        
        player.HP -= 15;
        UIManager.instance.ShowNotiText($"Hurt -15\nHP: {player.HP}");

        if (player.HP <= 0)
        {
            UIManager.instance.ShowNotiText($"Hurt -15\nHP: im fucking DEAD\n with {player.Point} points!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rd.material.color = new Color32(147, 50, 0, 255);
    }
}
