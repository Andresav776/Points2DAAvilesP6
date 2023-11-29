using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2Goal : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform goal;
    public float accuracy = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.LookAt(goal.position);
        Vector3 direction = goal.position - this.transform.position;
        if (direction.magnitude > accuracy)
        {
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
