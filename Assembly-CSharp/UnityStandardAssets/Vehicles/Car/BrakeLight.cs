using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051C RID: 1308
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x0600214F RID: 8527 RVA: 0x001E77F5 File Offset: 0x001E59F5
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002150 RID: 8528 RVA: 0x001E7803 File Offset: 0x001E5A03
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x0400491D RID: 18717
		public CarController car;

		// Token: 0x0400491E RID: 18718
		private Renderer m_Renderer;
	}
}
