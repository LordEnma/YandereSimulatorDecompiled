using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021A8 RID: 8616 RVA: 0x001ECF0B File Offset: 0x001EB10B
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021A9 RID: 8617 RVA: 0x001ECF1C File Offset: 0x001EB11C
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

		// Token: 0x060021AA RID: 8618 RVA: 0x001ECF80 File Offset: 0x001EB180
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x040049DC RID: 18908
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x040049DD RID: 18909
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x040049DE RID: 18910
		private float m_LastOkTime;

		// Token: 0x040049DF RID: 18911
		private Rigidbody m_Rigidbody;
	}
}
