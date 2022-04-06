using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000534 RID: 1332
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021DF RID: 8671 RVA: 0x001F0D31 File Offset: 0x001EEF31
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x001F0D44 File Offset: 0x001EEF44
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004A76 RID: 19062
		public CarController carController;

		// Token: 0x04004A77 RID: 19063
		private Quaternion m_OriginalRotation;
	}
}
