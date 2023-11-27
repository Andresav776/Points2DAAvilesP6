using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMove : MonoBehaviour
{
    public Vector3 location = new Vector3(-2, 6, 0);
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.Translate(location.normalized * speed * Time.deltaTime);
    }
}
