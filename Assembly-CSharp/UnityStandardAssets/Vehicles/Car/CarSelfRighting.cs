using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000526 RID: 1318
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x06002199 RID: 8601 RVA: 0x001EB953 File Offset: 0x001E9B53
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600219A RID: 8602 RVA: 0x001EB964 File Offset: 0x001E9B64
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

		// Token: 0x0600219B RID: 8603 RVA: 0x001EB9C8 File Offset: 0x001E9BC8
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x040049AF RID: 18863
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x040049B0 RID: 18864
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x040049B1 RID: 18865
		private float m_LastOkTime;

		// Token: 0x040049B2 RID: 18866
		private Rigidbody m_Rigidbody;
	}
}
