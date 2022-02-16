using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class ExampleWheelController : MonoBehaviour
{
	// Token: 0x06000963 RID: 2403 RVA: 0x0004B2CF File Offset: 0x000494CF
	private void Start()
	{
		this.m_Rigidbody = base.GetComponent<Rigidbody>();
		this.m_Rigidbody.maxAngularVelocity = 100f;
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x0004B2F0 File Offset: 0x000494F0
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

	// Token: 0x04000801 RID: 2049
	public float acceleration;

	// Token: 0x04000802 RID: 2050
	public Renderer motionVectorRenderer;

	// Token: 0x04000803 RID: 2051
	private Rigidbody m_Rigidbody;

	// Token: 0x02000645 RID: 1605
	private static class Uniforms
	{
		// Token: 0x04004E8E RID: 20110
		internal static readonly int _MotionAmount = Shader.PropertyToID("_MotionAmount");
	}
}
