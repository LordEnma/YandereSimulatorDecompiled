using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000525 RID: 1317
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x0600218F RID: 8591 RVA: 0x001EB29B File Offset: 0x001E949B
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002190 RID: 8592 RVA: 0x001EB2AC File Offset: 0x001E94AC
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

		// Token: 0x06002191 RID: 8593 RVA: 0x001EB310 File Offset: 0x001E9510
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x040049A3 RID: 18851
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x040049A4 RID: 18852
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x040049A5 RID: 18853
		private float m_LastOkTime;

		// Token: 0x040049A6 RID: 18854
		private Rigidbody m_Rigidbody;
	}
}
