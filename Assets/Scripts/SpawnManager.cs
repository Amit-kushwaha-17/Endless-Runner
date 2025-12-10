using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawn = new Vector3(25,0,0);
    public GameObject obstacleObject;
    private float startDelay = 2f;
    private float repeatInterval = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, Random.Range(repeatInterval,4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        Instantiate(obstacleObject, spawn, obstacleObject.transform.rotation);
    }
}
