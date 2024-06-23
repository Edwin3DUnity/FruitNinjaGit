using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollow : MonoBehaviour
{


    [SerializeField] public Camera _Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = _Camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y);

        transform.position = mousePos;
    }
}
