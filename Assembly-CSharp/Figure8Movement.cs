using System;
using UnityEngine;

public class Figure8Movement : MonoBehaviour
{
	public float speed = 2f;

	public float scaleX = 2f;

	public float scaleZ = 3f;

	public float offsetX;

	public float offsetZ;

	public bool isLinkOffsetScalePositiveX;

	public bool isLinkOffsetScaleNegativeX;

	public bool isLinkOffsetScalePositiveZ;

	public bool isLinkOffsetScaleNegativeZ;

	public bool isFigure8 = true;

	private float phase;

	private float m_2PI = MathF.PI * 2f;

	private Vector3 originalPosition;

	private Vector3 pivot;

	private Vector3 pivotOffset;

	private bool isInverted;

	private bool isRunning;

	private void Start()
	{
		pivot = base.transform.localPosition;
		originalPosition = base.transform.localPosition;
		isRunning = true;
		if (isLinkOffsetScalePositiveX)
		{
			phase = 4.71f;
		}
		else if (isLinkOffsetScaleNegativeX)
		{
			phase = 1.57f;
		}
		else if (isLinkOffsetScalePositiveZ)
		{
			phase = 3.14f;
		}
		else
		{
			phase = 0f;
		}
	}

	private void Update()
	{
		pivotOffset = Vector3.forward * 2f * scaleZ;
		phase += speed * Time.deltaTime;
		if (isFigure8)
		{
			if (phase > m_2PI)
			{
				isInverted = !isInverted;
				phase -= m_2PI;
			}
			if (phase < 0f)
			{
				phase += m_2PI;
			}
		}
		Vector3 vector = pivot + (isInverted ? pivotOffset : Vector3.zero);
		base.transform.localPosition = new Vector3(vector.x + Mathf.Sin(phase) * scaleX + offsetX, vector.y, vector.z + Mathf.Cos(phase) * (float)((!isInverted) ? 1 : (-1)) * scaleZ + offsetZ);
	}

	private void OnDrawGizmos()
	{
		if (isLinkOffsetScalePositiveX)
		{
			offsetX = scaleX;
		}
		else if (isLinkOffsetScaleNegativeX)
		{
			offsetX = scaleX * -1f;
		}
		else
		{
			offsetX = 0f;
		}
		if (isLinkOffsetScalePositiveZ)
		{
			offsetZ = scaleZ;
		}
		else if (isLinkOffsetScaleNegativeZ)
		{
			offsetZ = scaleZ * -1f;
		}
		else
		{
			offsetZ = 0f;
		}
		if (isRunning)
		{
			Gizmos.DrawLine(new Vector3(originalPosition.x + offsetX, originalPosition.y, originalPosition.z + scaleZ + offsetZ), new Vector3(originalPosition.x + offsetX, originalPosition.y, originalPosition.z + offsetZ));
			Gizmos.DrawLine(new Vector3(originalPosition.x + offsetX, originalPosition.y, originalPosition.z - scaleZ + offsetZ), new Vector3(originalPosition.x + offsetX, originalPosition.y, originalPosition.z + offsetZ));
			Gizmos.DrawLine(new Vector3(originalPosition.x + scaleX + offsetX, originalPosition.z + offsetZ, originalPosition.y), new Vector3(originalPosition.x + offsetX, originalPosition.y, originalPosition.z + offsetZ));
			Gizmos.DrawLine(new Vector3(originalPosition.x - scaleX + offsetX, originalPosition.z + offsetZ, originalPosition.y), new Vector3(originalPosition.x + offsetX, originalPosition.y, originalPosition.z + offsetZ));
		}
		else
		{
			Gizmos.DrawLine(new Vector3(base.transform.localPosition.x + offsetX, base.transform.localPosition.y, base.transform.localPosition.z + scaleZ + offsetZ), new Vector3(base.transform.localPosition.x + offsetX, base.transform.localPosition.y, base.transform.localPosition.z + offsetZ));
			Gizmos.DrawLine(new Vector3(base.transform.localPosition.x + offsetX, base.transform.localPosition.y, base.transform.localPosition.z - scaleZ + offsetZ), new Vector3(base.transform.localPosition.x + offsetX, base.transform.localPosition.y, base.transform.localPosition.z + offsetZ));
			Gizmos.DrawLine(new Vector3(base.transform.localPosition.x + scaleX + offsetX, base.transform.localPosition.y, base.transform.localPosition.z + offsetZ), new Vector3(base.transform.localPosition.x + offsetX, base.transform.localPosition.y, base.transform.localPosition.z + offsetZ));
			Gizmos.DrawLine(new Vector3(base.transform.localPosition.x - scaleX + offsetX, base.transform.localPosition.y, base.transform.localPosition.z + offsetZ), new Vector3(base.transform.localPosition.x + offsetX, base.transform.localPosition.y, base.transform.localPosition.z + offsetZ));
		}
	}
}
