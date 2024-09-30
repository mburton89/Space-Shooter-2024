using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float driftRadius;           //Radius of movement
    public float driftSpeed;            //Speed of movement

    private Vector2 initialPosition;    //Initial position of the object to be moved
    private float timeOffset;           //Random amount of time between movements?


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;           //stores the position of the object to move
        timeOffset = Random.Range(0f, 2);               //Applies the offset for the time between movements
    }

    // Update is called once per frame
    void Update()
    {
        //Object moves in a circle
        float x = initialPosition.x + Mathf.Cos(Time.time * driftSpeed + timeOffset) * driftRadius;
        float y = initialPosition.y + Mathf.Sin(Time.time * driftSpeed + timeOffset) * driftRadius;
        transform.position = new Vector2(x, y);
    }
}
