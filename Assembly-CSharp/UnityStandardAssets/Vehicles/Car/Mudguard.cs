using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021A0 RID: 8608 RVA: 0x001EBA71 File Offset: 0x001E9C71
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021A1 RID: 8609 RVA: 0x001EBA84 File Offset: 0x001E9C84
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x040049B4 RID: 18868
		public CarController carController;

		// Token: 0x040049B5 RID: 18869
		private Quaternion m_OriginalRotation;
	}
}
