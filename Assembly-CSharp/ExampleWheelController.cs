using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class ExampleWheelController : MonoBehaviour
{
	// Token: 0x06000963 RID: 2403 RVA: 0x0004B2D7 File Offset: 0x000494D7
	private void Start()
	{
		this.m_Rigidbody = base.GetComponent<Rigidbody>();
		this.m_Rigidbody.maxAngularVelocity = 100f;
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x0004B2F8 File Offset: 0x000494F8
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

	// Token: 0x040007FF RID: 2047
	public float acceleration;

	// Token: 0x04000800 RID: 2048
	public Renderer motionVectorRenderer;

	// Token: 0x04000801 RID: 2049
	private Rigidbody m_Rigidbody;

	// Token: 0x02000647 RID: 1607
	private static class Uniforms
	{
		// Token: 0x04004E7B RID: 20091
		internal static readonly int _MotionAmount = Shader.PropertyToID("_MotionAmount");
	}
}
