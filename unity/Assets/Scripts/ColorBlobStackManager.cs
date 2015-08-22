using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Color Blob stack manager attached to RenderToTextureCamera.
/// </summary>
[RequireComponent(typeof(Camera))]
public class ColorBlobStackManager : Singleton<ColorBlobStackManager> {
	
	public SpericalColorBlob blackSpherePrefab;
	public SpericalColorBlob whiteSpherePrefab;
	
	private Stack<ColorBlob> colorStack;
	private Camera renderTextureCamera;
	
	private const float DistanceBetweenLayers = 0.01f;
	
	public void PushColorBlob(ColorBlob blob)
	{
		colorStack.Push(blob);
		transform.position = transform.position + Vector3.up * DistanceBetweenLayers;
		renderTextureCamera.farClipPlane += DistanceBetweenLayers;
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
		
		spawnedBlob.transform.position = new Vector3(position.x, transform.position.y + 1, position.y);
		
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
