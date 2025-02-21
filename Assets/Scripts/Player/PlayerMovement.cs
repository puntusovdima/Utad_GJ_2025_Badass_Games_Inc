using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _rb;
    public StateManager sm;
    public float speed = 5f;
    public bool canMove = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        sm = GetComponent<StateManager>();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
        // Debug.Log("horizotal input:" + Input.GetAxis("Horizontal"));
        Vector2 move = new Vector2(horizontalInput * Time.fixedDeltaTime * speed, 0);
        _rb.MovePosition(_rb.position + move);
        // _rb.velocity += move;
        
    }
}
