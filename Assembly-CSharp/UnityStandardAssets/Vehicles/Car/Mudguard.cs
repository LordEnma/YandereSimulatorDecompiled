using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000534 RID: 1332
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021E6 RID: 8678 RVA: 0x001F178D File Offset: 0x001EF98D
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001F17A0 File Offset: 0x001EF9A0
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004A88 RID: 19080
		public CarController carController;

		// Token: 0x04004A89 RID: 19081
		private Quaternion m_OriginalRotation;
	}
}
