using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Transform transform;

    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Time.deltaTime);
    }
}
