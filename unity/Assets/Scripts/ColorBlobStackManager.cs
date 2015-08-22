using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Color Blob stack manager attached to RenderToTextureCamera.
/// </summary>
[RequireComponent(typeof(Camera))]
public class ColorBlobStackManager : Singleton<ColorBlobStackManager> {
	#region inspector variables
	public SpericalColorBlob blackSpherePrefab;
	public SpericalColorBlob whiteSpherePrefab;
	#endregion
	
	#region private variables 	
	private Stack<ColorBlob> colorStack;
	private Camera renderTextureCamera;
	
	private const float DistanceBetweenLayers = 0.01f;
	#endregion
	
	public void PushColorBlob(ColorBlob blob)
	{
		colorStack.Push(blob);
		
		float blobObjectHeight = blob.GetComponent<Collider>().bounds.extents.y;
		
		transform.position += Vector3.up * (DistanceBetweenLayers + blobObjectHeight);
		
		renderTextureCamera.farClipPlane += DistanceBetweenLayers + blobObjectHeight;
	}
	
	public void SpawnSpericalColorBlob(ColorBlob.BlobColor color, Vector2 position, float radius = 1.0f)
	{
		SpericalColorBlob spawnedBlob = null;
		switch (color) {
		case ColorBlob.BlobColor.Black:
			spawnedBlob = Instantiate(blackSpherePrefab);
			break;
		case ColorBlob.BlobColor.White:
			spawnedBlob = Instantiate(whiteSpherePrefab);
			break;
		default:
			break;
		}
		
		spawnedBlob.Radius = radius;
		
		spawnedBlob.transform.position = new Vector3(position.x, -1, position.y) + transform.position;
		
		spawnedBlob.transform.SetParent(transform);
		
		PushColorBlob(spawnedBlob);
	}
	
	
	protected override void Awake ()
	{
		base.Awake ();
		colorStack = new Stack<ColorBlob>();
		renderTextureCamera = GetComponent<Camera>();
	}
}
