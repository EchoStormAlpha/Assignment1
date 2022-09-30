using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float offset, speed;

    public AnimationCurve height, movement;
    
    public Transform cubeA, cubeB;
    //public Vector3 cubeScaleA, cubeScaleB;
    private float rate;

    private Vector3 desiredPosition;
    
    // Update is called once per frame
    void Update()
    {
        rate += Time.deltaTime * speed;



        desiredPosition = Vector3.Lerp(cubeA.position, cubeB.position, movement.Evaluate(rate));

        desiredPosition.y += height.Evaluate(rate) + offset;

        transform.position = desiredPosition;
       
        if (rate >= 1)
        {
            rate = 0;
        }

    }
}
