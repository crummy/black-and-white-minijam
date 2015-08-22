using UnityEngine;
using System.Collections;

public class CountPixels : MonoBehaviour
{

    public float timeLimit = 60;


    public float endtime;

    public GameObject[] turnObjectsOff;
    public BoxCollider box;
    public Camera mainCam;

    public bool countScore = false;
    private bool executetUpdateBefore = false;

    public float whiteScore = 0.5f;

    private Vector2 screenMin;
    private Vector2 screenMax;

    public bool endGame = false;

    public float blackScore
    {
        get { return 1 - whiteScore;  }
    }

	// Use this for initialization
	void Start ()
	{
	    mainCam = GetComponent<Camera>();
        endtime = Time.time + timeLimit;
	}

    private void SwitchGameObjects(bool hide)
    {
        if (turnObjectsOff != null)
        {
            for (int i = 0; i < turnObjectsOff.Length; i++)
            {
                Renderer r = turnObjectsOff[i].GetComponent<Renderer>();
                r.enabled = !hide;
            }
        }
    }

    public void HideGameObjects()
    {
        SwitchGameObjects(true);
    }

    public void ShowGameObjects()
    {
        SwitchGameObjects(false);
    }

    public void Update()
    {
        if (Time.time > endtime && !endGame)
        {
            countScore = true;
            endGame = true;
        }

        if (countScore)
        {
            HideGameObjects();
            executetUpdateBefore = true;
        }
    }

    public void OnPostRender()
    {
        if (countScore && executetUpdateBefore)
        {
            Vector3 min = box.bounds.min;
            min = new Vector3(min.x,0,min.z);
            Vector3 max = box.bounds.max;
            max = new Vector3(max.x, 0, max.z);

            screenMin = mainCam.WorldToScreenPoint(min);
            screenMax = mainCam.WorldToScreenPoint(max);

            Vector2 size = screenMax - screenMin;

            Texture2D tex = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, true);
            tex.ReadPixels(new Rect(screenMin.x, screenMin.y, tex.width, tex.height), 0, 0, false);

            whiteScore = 0;

            for (int x = 0; x < tex.width; x++)
            {
                for (int y = 0; y < tex.height; y++)
                {
                    if (tex.GetPixel(x, y).r > 0.5f)
                    {
                        whiteScore++;
                    }
                }
            }
            float pixelAmount = tex.width*tex.height;
            whiteScore /= pixelAmount;

            countScore = false;
            executetUpdateBefore = false;
            ShowGameObjects();
        }
    }

    public void OnGUI()
    {
        //GUI.Box(new Rect(screenMin, screenMax - screenMin), "Test");
        GUI.Label(new Rect(0, 0, 300, 25), "Remaning Time " + (endtime-Time.time));

        if (endGame)
        {
            GUI.Label(new Rect(0, 0, 300, 25), "Remaning Time 0");
            GUI.Label(new Rect(0, 30, 300, 25), "White has " + (whiteScore*100) + " Black has " + (blackScore*100));

        }
        else
        {
            GUI.Label(new Rect(0, 0, 300, 25), "Remaning Time " + (endtime - Time.time));
    
        }
    }
}
