using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000534 RID: 1332
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021F3 RID: 8691 RVA: 0x001F4247 File Offset: 0x001F2447
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001F4258 File Offset: 0x001F2458
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

		// Token: 0x060021F5 RID: 8693 RVA: 0x001F42BC File Offset: 0x001F24BC
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004AC0 RID: 19136
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004AC1 RID: 19137
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004AC2 RID: 19138
		private float m_LastOkTime;

		// Token: 0x04004AC3 RID: 19139
		private Rigidbody m_Rigidbody;
	}
}
