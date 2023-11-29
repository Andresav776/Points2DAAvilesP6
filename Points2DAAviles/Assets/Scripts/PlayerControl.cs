using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    public GameObject target;
    public Transform target0;
    public float accuracy = 6;

    bool autoPilot = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        rotation *= Time.deltaTime;
        translation *= Time.deltaTime;

        transform.Translate(0, translation, 0);

        transform.Rotate(0, 0, -rotation);

        if (Input.GetKey(KeyCode.Space))
        {
            CalculateDistance();
            CalculateAngle();
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            autoPilot = !autoPilot;
        }

        else if (autoPilot)
        {
            AutoPilot();
        }
    }

    void CalculateDistance()
    {
        Vector3 pP = this.transform.position;
        Vector3 tP = target.transform.position;

        float distance = Vector3.Distance(pP, tP);
        Debug.Log("Distance from Target: " + distance);
    }

    void CalculateAngle()
    {
        Vector3 pO = this.transform.up;
        Vector3 tO = target.transform.position - this.transform.position;

        float dot = pO.x * tO.x + pO.y + tO.y;
        float angle = Vector3.SignedAngle(pO, tO, this.transform.forward);

        Debug.Log("Angle: " + Vector3.Angle(pO, tO));

        Debug.DrawRay(this.transform.position, pO * 10, Color.blue, 2);
        Debug.DrawRay(this.transform.position, tO, Color.red, 2);

        this.transform.Rotate(0, 0, angle);
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.z * w.x - v.x * w.z;
        float zMult = v.x * w.y - v.y * w.x;

        Vector3 crossProduct = new Vector3(xMult, yMult, zMult);
        return crossProduct;
    }

    void AutoPilot()
    {
        CalculateAngle();
        Vector3 direction = target0.position - this.transform.position;
        this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
