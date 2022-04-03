using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000531 RID: 1329
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021D0 RID: 8656 RVA: 0x001F06E3 File Offset: 0x001EE8E3
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001F06F4 File Offset: 0x001EE8F4
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

		// Token: 0x060021D2 RID: 8658 RVA: 0x001F0758 File Offset: 0x001EE958
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004A6D RID: 19053
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004A6E RID: 19054
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004A6F RID: 19055
		private float m_LastOkTime;

		// Token: 0x04004A70 RID: 19056
		private Rigidbody m_Rigidbody;
	}
}
