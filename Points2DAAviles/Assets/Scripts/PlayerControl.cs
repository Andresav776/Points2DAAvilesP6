using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    public GameObject enemy1;
    public GameObject enemy2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        rotation *= Time.deltaTime;
        translation *= Time.deltaTime;

        transform.Translate(0, translation, 0);

        transform.Rotate(0, 0, -rotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateDistance1();
            CalculateDistance2();
            CalculateAngle1();
            CalculateAngle2();
        }
    }

    void CalculateDistance1()
    {
        Vector3 playerPosition = this.transform.position;
        Vector3 enemy1Position = enemy1.transform.position;

        float distance = Vector3.Distance(playerPosition, enemy1Position);
        Debug.Log("Distance from Square: " + distance);
    }

    void CalculateDistance2()
    {
        Vector3 playerPosition = this.transform.position;
        Vector3 enemy2Position = enemy2.transform.position;

        float distance = Vector3.Distance(playerPosition, enemy2Position);
        Debug.Log("Distance from Circle: " + distance);
    }

    void CalculateAngle1()
    {
        Vector3 playerOrientation = this.transform.up;
        Vector3 enemy1Orientation = enemy1.transform.position - this.transform.position;

        Debug.DrawRay(this.transform.position, playerOrientation, Color.blue, 2);
        Debug.DrawRay(this.transform.position, enemy1Orientation, Color.red, 2);
    }

    void CalculateAngle2()
    {
        Vector3 playerOrientation = this.transform.up;
        Vector3 enemy2Orientation = enemy2.transform.position - this.transform.position;

        Debug.DrawRay(this.transform.position, enemy2Orientation, Color.red, 2);
    }
}
