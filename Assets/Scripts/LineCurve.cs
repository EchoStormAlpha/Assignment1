using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class LineCurve : MonoBehaviour
{
    

   

    

        [SerializeField]

        private LineRenderer lRenderer;

        [SerializeField]

        private Transform targetA, targetB;

        [Range(2, 100)]

        [SerializeField]

        private int lineResolution = 2;

        [SerializeField]

        private AnimationCurve lineCurvature;

      

    public List<Vector3> listOfPositions;//stores position of the previous frames line

    private void Start()


    {
        listOfPositions = new List<Vector3>();
        lRenderer = GetComponent<LineRenderer>();
        lRenderer.SetPosition(0, targetA.position);
        for(int x = 0; x < lRenderer.positionCount; x++)
        {
            listOfPositions.Add(lRenderer.GetPosition(x));
        }
        }

        void Update()

        {

            if (lRenderer.positionCount != lineResolution)

                lRenderer.positionCount = lineResolution;

            for (int x = 0; x < listOfPositions.Count; x++)//store the old positions
        {
            listOfPositions[x] = lRenderer.GetPosition(x);
        }
        lRenderer.SetPosition(0, targetA.position);//set first point to the target attached to the ball

        for (int x = 1; x < lRenderer.positionCount; x++)

        {
            //store position of current index
            // desiredPosition = Vector3.Lerp(lRenderer.GetPosition(x), lRenderer.GetPosition(x+1), x / (lRenderer.positionCount - 1.0f));



            lRenderer.SetPosition(x, (listOfPositions[x-1]));//set position of current index to position of the index before from previous frame.

            }

        }

    }

