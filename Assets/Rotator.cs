using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    float accuracy = 0.005f;
    [SerializeField]
    float step = 1f;
    [SerializeField]
    private List<Transform> topBounds;
    [SerializeField]
    private List<Transform> bottomBounds;

    // Update is called once per frame
    void Update()
    {

        //Отрисовка лучей в юнити и управление на W/S
        #if UNITY_EDITOR
        foreach(Transform top in topBounds)
        {
            Debug.DrawRay(top.position, top.TransformDirection(Vector3.down) * accuracy, Color.red);
        }
        foreach (Transform bottom in bottomBounds)
        {
            Debug.DrawRay(bottom.position, bottom.TransformDirection(Vector3.down) * accuracy, Color.red);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Rotate(1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rotate(-1);
        }
        #endif
    }


    ///<summary>
    ///Positive dir rotating forward.
    ///Negative dir rotating backward
    ///</summary>
    public void Rotate(int dir)
    {
        RaycastHit hit;
        bool colliding = false;
        if (dir > 0)
        {
            foreach(Transform top in topBounds)
            if (Physics.Raycast(top.transform.position, top.transform.TransformDirection(Vector3.down), out hit, accuracy))
            {
                    colliding = true;
            }
            if (!colliding)
            {
                transform.Rotate(step * Time.deltaTime, 0, 0);
            }
        }
        if (dir < 0)
        {
            foreach (Transform bottom in bottomBounds)
                if (Physics.Raycast(bottom.transform.position, bottom.transform.TransformDirection(Vector3.down), out hit, accuracy))
                {
                    colliding = true;
                }
            if (!colliding)
            {
                transform.Rotate(-step * Time.deltaTime, 0, 0);
            }
        }
    }

    
}
