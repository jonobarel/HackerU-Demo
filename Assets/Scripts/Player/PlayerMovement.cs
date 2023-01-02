using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] [Range(1f,10f)] private float jumpPower;
    [SerializeField] private int score;   

    private Rigidbody2D rb2d;

    private bool _doJump;
    private float horizontalAxis;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    [SerializeField]
    public bool isGrounded;

    private ScoreUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreUI = FindObjectOfType<ScoreUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontalAxis * speed, rb2d.velocity.y);
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
            InitiateJump();

        }

        horizontalAxis = Input.GetAxis("Horizontal");

    }

    public void InitiateJump()
    {
        if (isGrounded)
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
            scoreUI.SetScore(score);

            Debug.Log(collision.gameObject.name + " picked up by the player! The total score is: " + score);
            Debug.Log("");
            
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
