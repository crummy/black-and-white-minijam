using UnityEngine;
using System.Collections;

public class RayCastTeset : MonoBehaviour {

    public Vector3 offset = new Vector3(0,0,100);
    public GameObject prefab;

    public bool blackColor = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;



            if (Physics.Raycast(ray, out hit))
            {
                GameObject ge = (GameObject) Instantiate(prefab, hit.point + offset, Quaternion.LookRotation(Vector3.left));
                if(blackColor)
                    ge.GetComponent<Shoot>().color = Color.black;
            }
        }	
	}
}
