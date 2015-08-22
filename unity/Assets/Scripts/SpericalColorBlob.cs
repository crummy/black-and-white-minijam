using UnityEngine;
using System.Collections;

public class SpericalColorBlob : ColorBlob {
	private float radius;
	public float Radius
	{
		get
		{
			return radius;
		}
		set
		{
			transform.localScale = new Vector3(value, value, value);
			radius = value;
		}
	}
}
