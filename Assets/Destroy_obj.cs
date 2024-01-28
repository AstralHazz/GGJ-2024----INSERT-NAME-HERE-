using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_obj : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(obj);
        }
    }
}
