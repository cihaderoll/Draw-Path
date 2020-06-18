using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    public static drawLine instantiate;



    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;
    public bool isDrawing;



    private void Awake()
    {
        instantiate = this;
    }

    void Start()
    {
       
    }

    
    void Update()
    {

        
        
    }

    private void FixedUpdate()
    {
        if (oyunKontrol.instantiate.stop && oyunKontrol.instantiate.draw)
        {
            if (Input.GetMouseButtonDown(0) && oyunKontrol.instantiate.ınkLevel > 0 && oyunKontrol.instantiate.totalDistance >= 0f)
            {
                CreateLine();
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                fingerPositions.Clear();
            }

            if (Input.GetMouseButton(0))
            {

                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f
                    && Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) < 2f
                    && oyunKontrol.instantiate.ınkLevel > 0
                    && oyunKontrol.instantiate.totalDistance >= 0f
                   )
                {
                    oyunKontrol.instantiate.totalDistance -= Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]);
                    UpdateLine(tempFingerPos);
                    //oyunKontrol.instantiate.ınkLevel--;
                }
            }
        }
        
    }


    void CreateLine()
    {
        
        currentLine = Instantiate(linePrefab, Vector2.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        
        edgeCollider.points = fingerPositions.ToArray();
    }
}
