using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] [Range(0f,10f)] private float jumpPower;
    [SerializeField] private int score;   

    private Rigidbody2D rb2d;

    private bool _doJump;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    [SerializeField]
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_doJump)
        {
            rb2d.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            isGrounded = false;
            _doJump = false;
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();
        }
    }

    public void DoJump()
    {
        if (!_doJump && isGrounded)
        {
            _doJump = true;
        }
    }

    private int SumNumbers(int num1, int num2)
    {
        int sumResult = num1 + num2;
        return sumResult;   
    }

    public void MyName(string name)
    {
        Debug.Log("My name is " + name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            int itemScoreToAdd = collision.gameObject.GetComponent<Item>().itemScore;
            score = score + itemScoreToAdd;

            Debug.Log(collision.gameObject.name + " picked up by the player! The total score is: " + score);
            Debug.Log("");
            Destroy(collision.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    public void ChangeJumpPower(float newJumpPower)
    {
        if (newJumpPower < 0)
        {
            return;
        }

        jumpPower = newJumpPower;
    }
}
