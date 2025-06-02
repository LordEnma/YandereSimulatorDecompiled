using System;
using UnityEngine;

[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	public Transform Target;

	public UITexture Tex;

	private void Start()
	{
		base.transform.LookAt(new Vector3(Target.position.x, base.transform.position.y, Target.position.z));
		Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = Vector3.one;
		Tex.color = new Color(Tex.color.r, Tex.color.g, Tex.color.b, 0f);
	}

	private void Update()
	{
		if (Tex.color.a > 0f && Target != null)
		{
			Vector3 worldPosition = new Vector3(Target.position.x, base.transform.position.y, Target.position.z);
			base.transform.LookAt(worldPosition);
		}
	}
}
