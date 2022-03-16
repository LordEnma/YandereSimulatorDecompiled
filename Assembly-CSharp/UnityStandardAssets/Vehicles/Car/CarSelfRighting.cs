using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052C RID: 1324
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021C0 RID: 8640 RVA: 0x001EEE73 File Offset: 0x001ED073
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x001EEE84 File Offset: 0x001ED084
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

		// Token: 0x060021C2 RID: 8642 RVA: 0x001EEEE8 File Offset: 0x001ED0E8
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004A3B RID: 19003
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004A3C RID: 19004
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004A3D RID: 19005
		private float m_LastOkTime;

		// Token: 0x04004A3E RID: 19006
		private Rigidbody m_Rigidbody;
	}
}
