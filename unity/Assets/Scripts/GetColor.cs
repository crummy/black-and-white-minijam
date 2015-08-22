using UnityEngine;
using System.Collections;
using UnityEditor;

public class GetColor : MonoBehaviour
{



    public void OnPostRender()
    {
        //if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Texture2D tex = new Texture2D(1, 1, TextureFormat.RGB24, true);
                tex.ReadPixels(new Rect(Input.mousePosition.x, Input.mousePosition.y, tex.width, tex.height), 0, 0, false);
                //Vector2 uv = hit.textureCoord;
                //Vector2 pixelCord = new Vector2(uv.x * texture.width, uv.y * texture.height);
                
                //Color c = texture.GetPixel((int)pixelCord.x, (int)pixelCord.y);
                //Debug.Log(tex.GetPixel(0,0));
            }
           
        }	
	}
}
