using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerDestroy : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        // Ray Information
        RaycastHit hitInfo;
        Ray rayforward = new Ray(transform.position, Vector3.forward);
        Ray rayback = new Ray(transform.position, Vector3.back);
        Ray rayleft = new Ray(transform.position, Vector3.left);
        Ray rayright = new Ray(transform.position, Vector3.right);
        Ray rayup = new Ray(transform.position, Vector3.up);
        Ray raydown = new Ray(transform.position, Vector3.down);

        // RaySpawn
        if (Physics.Raycast(rayforward, out hitInfo, 0.1f) 
			|| Physics.Raycast(rayback, out hitInfo, 0.1f) 
			|| Physics.Raycast(rayleft, out hitInfo, 0.1f)
			|| Physics.Raycast(rayright, out hitInfo, 0.1f) 
			|| Physics.Raycast(rayup, out hitInfo, 0.1f) 
			|| Physics.Raycast(raydown, out hitInfo, 0.1f))
        {
            Destroy(hitInfo.transform.gameObject);
        }
    }
}
