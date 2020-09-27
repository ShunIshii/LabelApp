using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlotsBehaviour : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData data)
    {
        transform.position += new Vector3(data.delta.x, 0f, 0f);
    }
}
