using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public GameObject target;
    public bool orbitY = true;
	public bool flipSpin = false;
	[HideInInspector]
	public float speed = 5;
	
	// Update is called once per frame
	void Update ()
    {

		if (target != null)
        {
            transform.LookAt(target.transform);

            if (orbitY)
            {
				if(flipSpin != true)
					transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
				else if (flipSpin == true)
					transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * speed);
            }
        }
	}

}
