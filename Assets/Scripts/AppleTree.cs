using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Prefab of instantiating apples
    public GameObject applePrefab; 

    //Speed at which the AppleTree Moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //chance that the appletree will change directions
    public float chanceToChangeDirection = 0.02f;

    //rate at which apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke("DropApple", 2f);

    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }
        
    }

    void FixedUpdate()
    {
        //changing direction randomly is now time-based because of FixedUpdate
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1; //change direction
        }
    }
}
