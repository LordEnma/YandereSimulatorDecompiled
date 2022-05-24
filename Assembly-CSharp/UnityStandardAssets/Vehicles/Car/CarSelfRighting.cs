using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000534 RID: 1332
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021F4 RID: 8692 RVA: 0x001F47AF File Offset: 0x001F29AF
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001F47C0 File Offset: 0x001F29C0
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

		// Token: 0x060021F6 RID: 8694 RVA: 0x001F4824 File Offset: 0x001F2A24
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004AC9 RID: 19145
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004ACA RID: 19146
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004ACB RID: 19147
		private float m_LastOkTime;

		// Token: 0x04004ACC RID: 19148
		private Rigidbody m_Rigidbody;
	}
}
