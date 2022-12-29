using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSc : MonoBehaviour
{
    public float c = 0f;
    public float a = 0f;
    Vector3 defPos;
    // Start is called before the first frame update
    void Start()
    {
        defPos = transform.localPosition - Vector3.up*c;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = defPos + Vector3.up*Mathf.Sin(a)*c + Vector3.right*Mathf.Cos(a)*c;
    }
}
