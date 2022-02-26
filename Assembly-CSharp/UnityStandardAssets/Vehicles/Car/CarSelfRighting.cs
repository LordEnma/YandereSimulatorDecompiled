using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021A2 RID: 8610 RVA: 0x001EC533 File Offset: 0x001EA733
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021A3 RID: 8611 RVA: 0x001EC544 File Offset: 0x001EA744
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

		// Token: 0x060021A4 RID: 8612 RVA: 0x001EC5A8 File Offset: 0x001EA7A8
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x040049BF RID: 18879
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x040049C0 RID: 18880
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x040049C1 RID: 18881
		private float m_LastOkTime;

		// Token: 0x040049C2 RID: 18882
		private Rigidbody m_Rigidbody;
	}
}
