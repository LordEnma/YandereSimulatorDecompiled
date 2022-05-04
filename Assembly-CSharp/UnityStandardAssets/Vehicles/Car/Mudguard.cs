using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000535 RID: 1333
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021F0 RID: 8688 RVA: 0x001F2D15 File Offset: 0x001F0F15
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001F2D28 File Offset: 0x001F0F28
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004A9E RID: 19102
		public CarController carController;

		// Token: 0x04004A9F RID: 19103
		private Quaternion m_OriginalRotation;
	}
}
