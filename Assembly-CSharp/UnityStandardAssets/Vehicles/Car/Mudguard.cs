using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000536 RID: 1334
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x060021FB RID: 8699 RVA: 0x001F48CD File Offset: 0x001F2ACD
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001F48E0 File Offset: 0x001F2AE0
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x04004ACE RID: 19150
		public CarController carController;

		// Token: 0x04004ACF RID: 19151
		private Quaternion m_OriginalRotation;
	}
}
