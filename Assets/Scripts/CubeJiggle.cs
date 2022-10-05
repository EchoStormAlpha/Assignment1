using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJiggle : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform jiggledObject;
    public AnimationCurve height;
    public bool jitter;
    public float rate=1.1f;
    public float speed;
    public Vector3 desiredPosition;
    public void OnTriggerEnter(Collider other)
    {
        jitter = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (jitter)
        {
            rate += Time.deltaTime;
            base.transform.localScale = new Vector3(base.transform.localScale.x, height.Evaluate(rate), base.transform.localScale.z);

            if (rate >= 1f)
            {
                rate = 0f;
                jitter = false;
            }
        }
    }
}
