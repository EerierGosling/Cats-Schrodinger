using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimator : MonoBehaviour
{
    public float AnimationTime = 1f;

    private LineRenderer lineRenderer;
    private Vector3[] LinePoints;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        LinePoints = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(LinePoints);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPositions(LinePoints);
    }

    public void ResetAnim()
    {
        if(lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 1;
        lineRenderer.SetPositions(LinePoints);
    }

    public void beginAnimation()
    {
        StartCoroutine(AnimateLine());
    }

    IEnumerator AnimateLine()
    {
        lineRenderer.SetPosition(0, LinePoints[0]);

        // calculate what percentage of the time each point should be reached
        float[] lengths = new float[LinePoints.Length - 1];
        float totalLength = 0f;

        for(int i = 0; i < lengths.Length; i++)
        {
            lengths[i] = Vector3.Distance(LinePoints[i], LinePoints[i + 1]);
            totalLength += lengths[i];
        }

        float[] timeAlloc = new float[lengths.Length];

        for(int i = 0; i < timeAlloc.Length; i++)
        {
            timeAlloc[i] = (lengths[i] / totalLength) * AnimationTime;
        }

        // loop until we reach the end of the line
        for(int i = 1; i < LinePoints.Length; i++)
        {
            float timeElapsed = 0f;
            lineRenderer.positionCount = i + 1;

            while(timeElapsed < timeAlloc[i - 1])
            {
                timeElapsed += Time.deltaTime;

                lineRenderer.SetPosition(i, Vector3.Lerp(LinePoints[i - 1], LinePoints[i], timeElapsed / timeAlloc[i - 1]));
                yield return null;
            }
        }
    }
}
