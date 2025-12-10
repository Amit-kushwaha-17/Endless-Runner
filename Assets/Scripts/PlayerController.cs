using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    public float jumpforce = 10;
    public float gravityModifier;
    private bool isOnGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround =false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround=true;
    }
}
