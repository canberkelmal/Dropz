using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSc : MonoBehaviour
{
    public float speed = 1f;
    public GameObject pin;
    public bool state = false;
    Vector3 defPos, targetPos;
    // Start is called before the first frame update
    void Start()
    {
        pin = transform.GetChild(0).gameObject;
        defPos = pin.transform.localPosition;
        targetPos = transform.GetChild(1).transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeState();
    }

    void ChangeState(){
        pin.transform.position = state ? Vector3.MoveTowards(pin.transform.position, defPos, speed * Time.deltaTime) : 
                                         Vector3.MoveTowards(pin.transform.position, targetPos, speed * Time.deltaTime);
    }

    public void trig(){
        state = !state;
    }
}
