using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class RotateObject : MonoBehaviour
{
    public Transform rotatedObject;
    public int xspeed=1;
    public int yspeed = 1;
    public int zspeed = 1;
   

    // Update is called once per frame
    void Update()
    {
        rotatedObject.Rotate(xspeed*Time.deltaTime, yspeed * Time.deltaTime, zspeed * Time.deltaTime);
    }
}
