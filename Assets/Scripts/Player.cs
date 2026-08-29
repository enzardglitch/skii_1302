using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float forcePower;

    [SerializeField]
    private Rigidbody rb;


    private Vector3 lastPos = new Vector3(0,0,0);

    private InputAction moveAction;
    private Vector2 moveValue;

    private float moveLast;

    [SerializeField]
    private int hp;
    public int HP { get { return hp; } set { hp = value; } }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSide();
    }

    private void MoveSide()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rb.AddForce(moveValue.x * Vector2.right * forcePower);
        Transform penguin = transform.Find("Penguin");
        float moveDelta = rb.linearVelocity.x - moveLast;
        moveLast = rb.linearVelocity.x;
        //penguin.rotation = Quaternion.Euler(45, moveDelta, 0);
    }
}
