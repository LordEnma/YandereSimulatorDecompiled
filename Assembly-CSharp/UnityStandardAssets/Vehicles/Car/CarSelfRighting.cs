using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000532 RID: 1330
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021D8 RID: 8664 RVA: 0x001F0C13 File Offset: 0x001EEE13
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x001F0C24 File Offset: 0x001EEE24
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

		// Token: 0x060021DA RID: 8666 RVA: 0x001F0C88 File Offset: 0x001EEE88
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004A71 RID: 19057
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004A72 RID: 19058
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004A73 RID: 19059
		private float m_LastOkTime;

		// Token: 0x04004A74 RID: 19060
		private Rigidbody m_Rigidbody;
	}
}
