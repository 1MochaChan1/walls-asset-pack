using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    private Vector2 startPos;
    private Vector2 endPos;



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        edgeCollider.transform.position -= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            startPos = new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0f);
        }

        if (Input.GetMouseButton(0))
        {

            endPos = new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0f);

            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);

            
        }

        //if (Input.GetMouseButtonUp(0)) {
        //    startPos = endPos;
        //}
        AddCollision();
    }

    void AddCollision()
    {
        List<Vector2> edgePos = new List<Vector2>();
        float lineWidth = lineRenderer.startWidth;

        for (int i = 0; i<lineRenderer.positionCount; i++)
        {
            Vector2 linePos =  lineRenderer.GetPosition(i);
            edgePos.Add(new Vector2(linePos.x, linePos.y+(lineWidth*.5f)));
        }

        edgeCollider.SetPoints(edgePos);
    }
}
