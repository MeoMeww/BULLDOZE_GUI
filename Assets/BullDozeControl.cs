using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullDozeControl : MonoBehaviour
{
    float smooth = 1.0f;
    public GameObject Lever;
    public GameObject Piston2;
    public GameObject Piston;
    public GameObject Piston21;
    public GameObject Piston003;
    public GameObject Piston001;
    public GameObject Ladle;
    private Quaternion targetRotation;
    private float lockRotate = 0f; 
    private float lockLever = 0f; 
    void Update()
    {


        if (Input.GetKey(KeyCode.T))
        {
            var move = new Vector3(1,0,0) ;
            transform.Translate(move * 5 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.G))
        {
            var move = new Vector3(-1, 0, 0);
            transform.Translate(move * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.F))
        {
            this.transform.Rotate(Vector3.down * 30 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.H))
        {
            this.transform.Rotate(Vector3.up * 30 * Time.deltaTime);
        }

        targetRotation = Lever.transform.rotation;
        if (Input.GetKey(KeyCode.A))
        {
            if (lockLever < 2.5)
            {
                targetRotation *= Quaternion.Euler(Vector3.forward);
                Lever.transform.rotation = Quaternion.Lerp(Lever.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston.transform.rotation = Quaternion.Lerp(Piston.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston2.transform.rotation = Quaternion.Lerp(Piston2.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston21.transform.rotation = Quaternion.Lerp(Piston21.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston003.transform.Translate(Vector3.right * (float)0.4 * Time.deltaTime);
                Piston001.transform.Translate(Vector3.right * (float)0.4 * Time.deltaTime);
                lockLever += (float)0.02;
            }
            Debug.Log("lockLever " + lockLever);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (lockLever > -0.4)
            {
                targetRotation *= Quaternion.Euler(Vector3.back);
                Lever.transform.rotation = Quaternion.Lerp(Lever.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston.transform.rotation = Quaternion.Lerp(Piston.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston2.transform.rotation = Quaternion.Lerp(Piston2.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston21.transform.rotation = Quaternion.Lerp(Piston21.transform.rotation, targetRotation, 20 * smooth * Time.deltaTime);
                Piston003.transform.Translate(Vector3.left * (float)0.4 * Time.deltaTime);
                Piston001.transform.Translate(Vector3.left * (float)0.4 * Time.deltaTime);
                lockLever -= (float)0.02;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {   if (lockRotate < 0.6) {
                Ladle.transform.Rotate(Vector3.back);
                lockRotate += (float)0.02;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (lockRotate > -0.3)
            {
                Ladle.transform.Rotate(Vector3.forward);
                lockRotate -= (float)0.02;
            }

        }
        ////Dampen towards the target rotation



    }
}
