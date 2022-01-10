using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000524 RID: 1316
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x06002187 RID: 8583 RVA: 0x001E9A13 File Offset: 0x001E7C13
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002188 RID: 8584 RVA: 0x001E9A24 File Offset: 0x001E7C24
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

		// Token: 0x06002189 RID: 8585 RVA: 0x001E9A88 File Offset: 0x001E7C88
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x0400498B RID: 18827
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x0400498C RID: 18828
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x0400498D RID: 18829
		private float m_LastOkTime;

		// Token: 0x0400498E RID: 18830
		private Rigidbody m_Rigidbody;
	}
}
