using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEditor;
using UnityEngine.UI;

public struct Point
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
    private CurrentBarBehaviour currentBarBehaviour;
    public List<Point> accList = new List<Point>();
    public List<GameObject> pointsList;
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private GameObject plotsObj;

    // Start is called before the first frame update
    void Start()
    {
        currentBarBehaviour = GetComponentInChildren<CurrentBarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void plot(List<Point> points)
    {
        float graphWidth = GetComponent<RectTransform>().sizeDelta.x;
        float graphHeight = GetComponent<RectTransform>().sizeDelta.y;
        double fs = points.Count / points.Last().elaspedTime;
        float interval = graphWidth / points.Count;
        float startPos = -(graphWidth / 2);
        Debug.Log("Fs = " + (int)fs + "Hz");

        pointsList = new List<GameObject>();
        foreach (var p in points.Select((value, index) => new { value, index}))
        {
            GameObject newPoint = Instantiate(pointPrefab, transform.position + new Vector3(startPos + interval * p.index, p.value.y * 5, 0), Quaternion.identity, plotsObj.transform);
            newPoint.GetComponent<Button>().onClick.AddListener(() => { currentBarBehaviour.OnClickPoint(p.index); });
            pointsList.Add(newPoint);
            if (p.index != 0)
            {
                GameObject pointA = pointsList[pointsList.Count - 2];
                GameObject pointB = pointsList[pointsList.Count - 1];

                Vector3 dtPos = pointB.transform.position - pointA.transform.position;
                Vector3 newPosition = pointA.transform.position + dtPos / 2;
                double newRotation = Math.Atan2(dtPos.y, dtPos.x) * 180d / Math.PI;

                GameObject line = Instantiate(linePrefab, newPosition, Quaternion.Euler(0, 0, (float)newRotation), plotsObj.transform);
                
                // Chage line length
                RectTransform t = line.GetComponent<RectTransform>();
                double lineLength = Math.Sqrt(Math.Pow(dtPos.x, 2) + Math.Pow(dtPos.y, 2));
                t.sizeDelta = new Vector2((float)lineLength, t.sizeDelta.y);
            }
        }
    }

    private void readData(string filePath)
    {
        StreamReader sr = new StreamReader(filePath);
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

    public void OnClickSelectButton()
    {
        readData(EditorUtility.OpenFilePanel("Select csv file", "", "csv"));
        plot(accList);
        currentBarBehaviour.SetGraphInfo(accList.Count);
    }
}
