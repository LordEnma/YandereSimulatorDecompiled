using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021A9 RID: 8617 RVA: 0x001EC651 File Offset: 0x001EA851
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021AA RID: 8618 RVA: 0x001EC664 File Offset: 0x001EA864
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x040049C4 RID: 18884
		public CarController carController;

		// Token: 0x040049C5 RID: 18885
		private Quaternion m_OriginalRotation;
	}
}
