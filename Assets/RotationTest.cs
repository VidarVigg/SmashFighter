using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float angle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(RotateRoutine());
        }
    }
    private IEnumerator RotateRoutine()
    {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        for (; ; )
        {
            transform.Rotate(0, 0, -5f);
            yield return null;
            Debug.Log(transform.rotation.z);
            if (transform.rotation.z < -0.9)
            {

                yield break;
            }
        }

    }
}
