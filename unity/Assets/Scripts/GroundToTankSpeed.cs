using UnityEngine;
using System.Collections;

public class GroundToTankSpeed : MonoBehaviour
{

    public PlayerController blackPlayer;
    private Transform blackHole;
    public PlayerController whitePlayer;
    private Transform whiteHole;
    public Camera mainCam;

    public float fastSpeed = 10;
    public float slowSpeed = 5;

	void Start () {
        mainCam = GetComponent<Camera>();
	    if (blackPlayer != null)
	    {
	        blackHole = blackPlayer.transform.FindChild("holde");
	    }
        if (whitePlayer != null)
        {
            whiteHole = whitePlayer.transform.FindChild("holde");
        }
	}
	

    public bool IsGroundColorWhite(Vector3 woldpos)
    {
        Vector2 sccenPos = mainCam.WorldToScreenPoint(woldpos);
        Texture2D tex = new Texture2D(1, 1, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect(sccenPos.x, sccenPos.y, tex.width, tex.height), 0, 0, false);

        //Debug.DrawLine(woldpos, woldpos + Vector3.up, tex.GetPixel(0, 0), 0.1f);
        
        if (tex.GetPixel(0, 0).r > 0.5f)
            return true;
        return false;
        
    }

    public void OnPostRender()
    {
        if (blackPlayer != null)
        {
            if (IsGroundColorWhite(blackHole.position))
            {
                //Slower bleckplayer
                blackPlayer.maxSpeed = slowSpeed;
            }
            else
            {
                blackPlayer.maxSpeed = fastSpeed;
            }
        }
        if (whitePlayer != null)
        {
            if (!IsGroundColorWhite(whiteHole.position))
            {
                //Slower whiteplayer
                whitePlayer.maxSpeed = slowSpeed;
            }
            else
            {
                whitePlayer.maxSpeed = fastSpeed;
            }
        }
    }
}
