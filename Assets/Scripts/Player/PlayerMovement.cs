using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _rb;
    //[SerializeField] public AnimatorController animationController;
    //[SerializeField] public AnimatorController animatorController;

    public Animator animAnim;
    public Animator animMove;

    public InteractionsManager interactionsManager;
    public StateManager sm;
    public float speed = 5f;
    public bool canMove = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        sm = GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
    }

    public void Update()
    {
        if (canMove)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                GetComponent<Animator>().SetBool("moving", true);
                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<Animator>().SetBool("moving", false);
                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("moving", false);
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (canMove && sm.state != 0)
        {
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

            if (move.magnitude > 0) AudioManager.instance.PlayStepSound();
            else AudioManager.instance.StopStepSound();
        }
    }
}
