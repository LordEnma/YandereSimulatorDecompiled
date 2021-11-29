using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051A RID: 1306
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x0600213E RID: 8510 RVA: 0x001E60C1 File Offset: 0x001E42C1
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x0600213F RID: 8511 RVA: 0x001E60CF File Offset: 0x001E42CF
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x040048DE RID: 18654
		public CarController car;

		// Token: 0x040048DF RID: 18655
		private Renderer m_Renderer;
	}
}
