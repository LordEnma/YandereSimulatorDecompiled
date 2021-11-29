using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000520 RID: 1312
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x06002168 RID: 8552 RVA: 0x001E734F File Offset: 0x001E554F
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06002169 RID: 8553 RVA: 0x001E7360 File Offset: 0x001E5560
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

		// Token: 0x0600216A RID: 8554 RVA: 0x001E73C4 File Offset: 0x001E55C4
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x0400492F RID: 18735
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004930 RID: 18736
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004931 RID: 18737
		private float m_LastOkTime;

		// Token: 0x04004932 RID: 18738
		private Rigidbody m_Rigidbody;
	}
}
