using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Color Blob stack manager attached to RenderToTextureCamera.
/// </summary>
[RequireComponent(typeof(Camera))]
public class ColorBlobStackManager : Singleton<ColorBlobStackManager> {
	
	private Stack<ColorBlob> colorStack;
	private Camera renderTextureCamera;
	
	public void PushColorBlob(ColorBlob blob)
	{
		colorStack.Push(blob);
	}
	
	protected override void Awake ()
	{
		base.Awake ();
		colorStack = new Stack<ColorBlob>();
		renderTextureCamera = GetComponent<Camera>();
	}
}
