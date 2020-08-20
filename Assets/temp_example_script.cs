using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_example_script : MonoBehaviour
{
    [SerializeField] Camera camera;
    Vector2 mousePosition;
    public Transform hamsterposition;
    

    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = camera.ScreenToWorldPoint(mousePosition);

            hamsterposition.position = mousePosition;
            Debug.Log(mousePosition);

        }
    }
}
