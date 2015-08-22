using UnityEngine;
using System.Collections;

public class RayCastTeset : MonoBehaviour {

    public Vector3 offset = new Vector3(0,0,100);
    public GameObject prefab;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                Instantiate(prefab, hit.point + offset, Quaternion.identity);
        }	
	}
}
