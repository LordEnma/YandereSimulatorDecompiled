using System;
using UnityEngine;

public class PerspectivePixelPerfect : MonoBehaviour
{
	[Tooltip("Bias is a value above 0 that determines how far offset the object will be from the near clip, in percent (near to far clip)")]
	public float bias = 0.001f;

	[ContextMenu("Execute")]
	private void Start()
	{
		Transform obj = base.transform;
		Camera main = Camera.main;
		float nearClipPlane = main.nearClipPlane;
		float farClipPlane = main.farClipPlane;
		float num = Mathf.Lerp(nearClipPlane, farClipPlane, bias);
		float fieldOfView = main.fieldOfView;
		float num2 = Mathf.Tan((float)Math.PI / 180f * fieldOfView * 0.5f) * num;
		obj.localPosition = new Vector3(0f, 0f, num);
		obj.localScale = new Vector3(num2, num2, 1f);
	}
}
