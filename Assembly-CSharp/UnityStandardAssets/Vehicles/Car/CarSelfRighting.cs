using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000532 RID: 1330
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021DF RID: 8671 RVA: 0x001F166F File Offset: 0x001EF86F
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x001F1680 File Offset: 0x001EF880
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

		// Token: 0x060021E1 RID: 8673 RVA: 0x001F16E4 File Offset: 0x001EF8E4
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004A83 RID: 19075
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004A84 RID: 19076
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004A85 RID: 19077
		private float m_LastOkTime;

		// Token: 0x04004A86 RID: 19078
		private Rigidbody m_Rigidbody;
	}
}
