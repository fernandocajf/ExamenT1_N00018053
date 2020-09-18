using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    private Transform bgTrasform;
    public GameObject target;

    private float y;
    // Start is called before the first frame update
    void Start()
    {
        bgTrasform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.transform.position.x;
        bgTrasform.position = new Vector3(x, bgTrasform.position.y, bgTrasform.position.z);
    }
}
