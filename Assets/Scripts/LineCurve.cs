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

        private Vector3 desiredPosition;



        private void Start()

        {

            lRenderer = GetComponent<LineRenderer>();

        }

        void Update()

        {

            if (lRenderer.positionCount != lineResolution)

                lRenderer.positionCount = lineResolution;



            for (int x = 0; x < lRenderer.positionCount; x++)

            {

                desiredPosition = Vector3.Lerp(targetA.position, targetB.position, x / (lRenderer.positionCount - 1.0f));



                lRenderer.SetPosition(x, new Vector3(desiredPosition.x,

                                            desiredPosition.y + lineCurvature.Evaluate(x / (lRenderer.positionCount - 1.0f)),

                                            desiredPosition.z));

            }

        }

    }

