using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000525 RID: 1317
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x06002192 RID: 8594 RVA: 0x001EB49F File Offset: 0x001E969F
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002193 RID: 8595 RVA: 0x001EB4B0 File Offset: 0x001E96B0
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

		// Token: 0x06002194 RID: 8596 RVA: 0x001EB514 File Offset: 0x001E9714
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x040049A6 RID: 18854
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x040049A7 RID: 18855
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x040049A8 RID: 18856
		private float m_LastOkTime;

		// Token: 0x040049A9 RID: 18857
		private Rigidbody m_Rigidbody;
	}
}
