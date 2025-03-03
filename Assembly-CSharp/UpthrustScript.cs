using System;
using UnityEngine;

public class UpthrustScript : MonoBehaviour
{
	[SerializeField]
	private float amplitude = 0.1f;

	[SerializeField]
	private float frequency = 0.6f;

	[SerializeField]
	private Vector3 rotationAmplitude = new Vector3(4.45f, 4.45f, 4.45f);

	private Vector3 startPosition;

	private void Start()
	{
		startPosition = base.transform.localPosition;
	}

	private void Update()
	{
		float num = amplitude * Mathf.Sin(MathF.PI * 2f * frequency * Time.time);
		base.transform.localPosition = startPosition + evaluatePosition(Time.time);
		base.transform.Rotate(rotationAmplitude * num);
	}

	private Vector3 evaluatePosition(float time)
	{
		float y = amplitude * Mathf.Sin(MathF.PI * 2f * frequency * time);
		return new Vector3(0f, y, 0f);
	}
}
