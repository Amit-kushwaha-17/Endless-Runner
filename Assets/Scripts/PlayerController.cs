using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody playerRB;
    private AudioSource playerAudio;
    public ParticleSystem deathpartical;
    public ParticleSystem dirtPartical;
    public AudioClip jumpSound;
    public AudioClip crashSound;
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
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameover)
        {
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround =false;
            animator.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtPartical.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtPartical.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {

            gameover = true;
            Debug.Log("Game Over");
            dirtPartical.Stop();
            deathpartical.Play();
          
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_Int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
