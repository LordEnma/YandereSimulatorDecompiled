using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052A RID: 1322
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021AF RID: 8623 RVA: 0x001ED029 File Offset: 0x001EB229
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x001ED03C File Offset: 0x001EB23C
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x040049E1 RID: 18913
		public CarController carController;

		// Token: 0x040049E2 RID: 18914
		private Quaternion m_OriginalRotation;
	}
}
