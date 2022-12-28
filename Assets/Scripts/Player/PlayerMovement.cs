using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] [Range(1f,10f)] private float jumpPower;
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
        //Changing how fast the player's rb2d is moving and in which direction.
        //(GetAxis saves us if statements)
        //Keeps the same velocity on Y and changes the velocity on X


        //rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);

        //for use in 3D, with normal rigidBody
        //rb.velocity = new Vector3(x, y, z);

        //If we had top down game movement style
        //rb2d.velocity = new Vector2(rb2d.velocity.x, Input.GetAxis("Vertical") * speed);
        //rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        //For 3D - (With Rigidbody "normal" component
        //rb2d.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y, rb2d.velocity.z);

        //Player movement on X axis
        #region
        float horizontalInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);

        //Flip player | Vector2(X, Y);
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector2(1, 1); // Vector2.one; //turn right (Vector2.one =  new Vector2(1,1));
        else if (horizontalInput < - 0.01f)
            transform.localScale = new Vector2(-1, 1); //turn left
        #endregion

        //When space is pressed, we will maintain the current velocity on the X Axis 
        //And apply a velocity of "speed" on the Y Axis
        if (_doJump)
        {
            rb2d.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            isGrounded = false;
            _doJump = false;
        }

    }

    public void Update()
    {
        if (!_doJump && Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
}
