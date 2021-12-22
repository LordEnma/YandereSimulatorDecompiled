using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000522 RID: 1314
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x06002179 RID: 8569 RVA: 0x001E8A83 File Offset: 0x001E6C83
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600217A RID: 8570 RVA: 0x001E8A94 File Offset: 0x001E6C94
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

		// Token: 0x0600217B RID: 8571 RVA: 0x001E8AF8 File Offset: 0x001E6CF8
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x0400496E RID: 18798
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x0400496F RID: 18799
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004970 RID: 18800
		private float m_LastOkTime;

		// Token: 0x04004971 RID: 18801
		private Rigidbody m_Rigidbody;
	}
}
