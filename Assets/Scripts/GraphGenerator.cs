using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

struct Point
{
    public float x;
    public float y;
    public float z;
    public float norm;
    public double elaspedTime;
    public long localTime;
}

public class GraphGenerator : MonoBehaviour
{
    private string filename = "eSense_003_20191217_044203.csv";
    private List<Point> accList = new List<Point>();
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject graphPanel;

    // Start is called before the first frame update
    void Start()
    {
        readData();
        plot(accList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void plot(List<Point> points)
    {
        var graphWidth = graphPanel.GetComponent<RectTransform>().sizeDelta.x;
        var graphHeight = graphPanel.GetComponent<RectTransform>().sizeDelta.y;
        var fs = points.Count / points.Last().elaspedTime;
        var interval = graphWidth / points.Count;
        var startPos = -(graphWidth / 2);
        Debug.Log("Fs = " + (int)fs + "Hz");

        List<GameObject> pointObj = new List<GameObject>();
        foreach (var p in points.Select((value, index) => new { value, index}))
        {
            pointObj.Add(Instantiate(pointPrefab, this.transform.position + new Vector3(startPos + interval * p.index, p.value.y * 5, 0), Quaternion.identity, graphPanel.transform));
            if (p.index != 0)
            {
                var pointA = pointObj[pointObj.Count - 2];
                var pointB = pointObj[pointObj.Count - 1];

                var dtPos = pointB.transform.position - pointA.transform.position;
                var newPosition = pointA.transform.position + dtPos / 2;
                var newRotation = Math.Atan2(dtPos.y, dtPos.x) * 180d / Math.PI;

                var line = Instantiate(linePrefab, newPosition, Quaternion.Euler(0, 0, (float)newRotation), graphPanel.transform);
                
                // Chage line length
                var t = line.GetComponent<RectTransform>();
                var lineLength = Math.Sqrt(Math.Pow(dtPos.x, 2) + Math.Pow(dtPos.y, 2));
                t.sizeDelta = new Vector2((float)lineLength, t.sizeDelta.y);
            }
        }
    }

    private void readData()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/Data/" + filename);
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] cell = line.Split(',');

            Point p;
            p.x = float.Parse(cell[0]);
            p.y = float.Parse(cell[1]);
            p.z = float.Parse(cell[2]);
            p.norm = p.x * p.x + p.y * p.y + p.z * p.z;
            p.elaspedTime = double.Parse(cell[3]);
            p.localTime = long.Parse(cell[4]);
            accList.Add(p);
        }
    }
}
