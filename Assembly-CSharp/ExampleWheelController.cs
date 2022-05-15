using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class ExampleWheelController : MonoBehaviour
{
	// Token: 0x06000963 RID: 2403 RVA: 0x0004B5BF File Offset: 0x000497BF
	private void Start()
	{
		this.m_Rigidbody = base.GetComponent<Rigidbody>();
		this.m_Rigidbody.maxAngularVelocity = 100f;
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x0004B5E0 File Offset: 0x000497E0
	private void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			this.m_Rigidbody.AddRelativeTorque(new Vector3(-1f * this.acceleration, 0f, 0f), ForceMode.Acceleration);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			this.m_Rigidbody.AddRelativeTorque(new Vector3(1f * this.acceleration, 0f, 0f), ForceMode.Acceleration);
		}
		float value = -this.m_Rigidbody.angularVelocity.x / 100f;
		if (this.motionVectorRenderer)
		{
			this.motionVectorRenderer.material.SetFloat(ExampleWheelController.Uniforms._MotionAmount, Mathf.Clamp(value, -0.25f, 0.25f));
		}
	}

	// Token: 0x0400080C RID: 2060
	public float acceleration;

	// Token: 0x0400080D RID: 2061
	public Renderer motionVectorRenderer;

	// Token: 0x0400080E RID: 2062
	private Rigidbody m_Rigidbody;

	// Token: 0x02000653 RID: 1619
	private static class Uniforms
	{
		// Token: 0x04004FA7 RID: 20391
		internal static readonly int _MotionAmount = Shader.PropertyToID("_MotionAmount");
	}
}
