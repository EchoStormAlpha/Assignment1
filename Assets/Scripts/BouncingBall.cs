using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float offset, speed;

    public AnimationCurve height, movement;
    public AnimationCurve cubeScale;
    public Transform cubeA, cubeB;
    //public Vector3 cubeScaleA, cubeScaleB;
    private float rate;

    private Vector3 desiredPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rate += Time.deltaTime * speed;



        desiredPosition = Vector3.Lerp(cubeA.position, cubeB.position, movement.Evaluate(rate));

        desiredPosition.y += height.Evaluate(rate) + offset;

        transform.position = desiredPosition;
        cubeA.localScale = new Vector3(1f, cubeScale.Evaluate(rate), 1f);
        if (rate >= 1)
        {
            rate = 0;
        }

    }
}
