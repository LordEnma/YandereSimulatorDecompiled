using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000525 RID: 1317
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x0600218D RID: 8589 RVA: 0x001EAF83 File Offset: 0x001E9183
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x001EAF94 File Offset: 0x001E9194
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

		// Token: 0x0600218F RID: 8591 RVA: 0x001EAFF8 File Offset: 0x001E91F8
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x0400499D RID: 18845
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x0400499E RID: 18846
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x0400499F RID: 18847
		private float m_LastOkTime;

		// Token: 0x040049A0 RID: 18848
		private Rigidbody m_Rigidbody;
	}
}
