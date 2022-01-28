using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    private float x;
    [SerializeField]
    private float y;
    private float z;
    private Vector3 pos;
    private bool done = true;
    void Start()
    {
     
    }

    private void Update()
    {
        if (done)
        {
            done = false;
            StartCoroutine(wait());
            
        }

    }
    IEnumerator wait()
    {

        x = Random.Range(-7, 8);
        //y = 1;
        z = Random.Range(-5, 9);
        pos = new Vector3(x, y, z);
        transform.position = pos;
     
        yield return new WaitForSeconds(8);
        done = true;



    }



}
