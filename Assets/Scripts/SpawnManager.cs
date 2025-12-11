using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawn = new Vector3(25,0,0);
    public GameObject obstacleObject;
    private float startDelay = 2f;
    private float repeatInterval = 2f;
    private PlayerController playerControllerscript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
       
        InvokeRepeating("SpawnObstacle", startDelay, repeatInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (playerControllerscript.gameover == false) {
            Instantiate(obstacleObject, spawn, obstacleObject.transform.rotation);
        }
  
    }
}
