using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    public float jumpforce = 10;
    public float gravityModifier;
    private bool isOnGround;
    public bool gameover=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameover)
        {
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround =false;
            animator.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameover = true;
            Debug.Log("Game Over");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_Int", 1);
        }
    }
}
