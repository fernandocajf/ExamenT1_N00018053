using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform cameraTrasform;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrasform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.transform.position.x;
        cameraTrasform.position = new Vector3(x, cameraTrasform.position.y, cameraTrasform.position.z);
    }
}