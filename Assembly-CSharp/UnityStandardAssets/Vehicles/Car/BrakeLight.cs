using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051F RID: 1311
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x0600215F RID: 8543 RVA: 0x001E9455 File Offset: 0x001E7655
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002160 RID: 8544 RVA: 0x001E9463 File Offset: 0x001E7663
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004941 RID: 18753
		public CarController car;

		// Token: 0x04004942 RID: 18754
		private Renderer m_Renderer;
	}
}
