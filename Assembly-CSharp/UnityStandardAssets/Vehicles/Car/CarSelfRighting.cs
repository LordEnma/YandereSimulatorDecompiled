using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000522 RID: 1314
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x0600217C RID: 8572 RVA: 0x001E9073 File Offset: 0x001E7273
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600217D RID: 8573 RVA: 0x001E9084 File Offset: 0x001E7284
		private void Update()
		{
			if (base.transform.up.y > 0f || this.m_Rigidbody.velocity.magnitude > this.m_VelocityThreshold)
			{
				this.m_LastOkTime = Time.time;
			}
			if (Time.time > this.m_LastOkTime + this.m_WaitTime)
			{
				this.RightCar();
			}
		}

		// Token: 0x0600217E RID: 8574 RVA: 0x001E90E8 File Offset: 0x001E72E8
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004977 RID: 18807
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004978 RID: 18808
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004979 RID: 18809
		private float m_LastOkTime;

		// Token: 0x0400497A RID: 18810
		private Rigidbody m_Rigidbody;
	}
}
