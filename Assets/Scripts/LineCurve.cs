using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class LineCurve : MonoBehaviour
{
    
        [SerializeField]

        private LineRenderer lRenderer;

    [SerializeField]

    private Transform targetA;//this is our target

        [Range(2, 100)]

        [SerializeField]

        private int lineResolution = 2;

        [SerializeField]

        private AnimationCurve lineCurvature;

      

    public List<Vector3> listOfPositions;//stores position of the previous frames line

    private void Start()


    {
        listOfPositions = new List<Vector3>();//this list is used to make a copy of the line renderer index
        lRenderer = GetComponent<LineRenderer>();
        lRenderer.SetPosition(0, targetA.position);//this starts the line render in the correct position
        for(int x = 0; x < lRenderer.positionCount; x++)
        {
            listOfPositions.Add(lRenderer.GetPosition(x));
        }
        }

        void Update()

        {

            if (lRenderer.positionCount != lineResolution)

                lRenderer.positionCount = lineResolution;

            for (int x = 0; x < listOfPositions.Count; x++)//store the positions of all points on the line renderer
                                                           //we use this to store where they were the frame before while we are updating the line renderer
        {
            listOfPositions[x] = lRenderer.GetPosition(x);
        }
        lRenderer.SetPosition(0, targetA.position);//The first point is always update to where its empty game object "target" is on the ball

        for (int x = 1; x < lRenderer.positionCount; x++)//we start at 1 because index 0 was set above

        {
            
            lRenderer.SetPosition(x, (listOfPositions[x-1]));//set position of current index to position of the index before from previous frame.

            }

        }

    }

