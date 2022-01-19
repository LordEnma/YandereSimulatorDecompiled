using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000525 RID: 1317
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x06002189 RID: 8585 RVA: 0x001EA6E3 File Offset: 0x001E88E3
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x0600218A RID: 8586 RVA: 0x001EA6F4 File Offset: 0x001E88F4
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

		// Token: 0x0600218B RID: 8587 RVA: 0x001EA758 File Offset: 0x001E8958
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004992 RID: 18834
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004993 RID: 18835
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004994 RID: 18836
		private float m_LastOkTime;

		// Token: 0x04004995 RID: 18837
		private Rigidbody m_Rigidbody;
	}
}
