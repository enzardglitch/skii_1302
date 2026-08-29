using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private int damage;
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
        AudioManager.instance.PlaySFX(1);
        GameManager.instance.TakeDamage(player, damage);
    }

    private void OnCollisionExit(Collision collision)
    {
        rd.material.color = new Color32(147, 50, 0, 255);
    }
}
