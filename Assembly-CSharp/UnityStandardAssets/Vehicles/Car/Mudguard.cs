using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000536 RID: 1334
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021FA RID: 8698 RVA: 0x001F4365 File Offset: 0x001F2565
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001F4378 File Offset: 0x001F2578
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004AC5 RID: 19141
		public CarController carController;

		// Token: 0x04004AC6 RID: 19142
		private Quaternion m_OriginalRotation;
	}
}
