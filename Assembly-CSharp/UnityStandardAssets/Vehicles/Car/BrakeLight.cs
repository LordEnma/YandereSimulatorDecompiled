using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051F RID: 1311
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x06002163 RID: 8547 RVA: 0x001E9CF5 File Offset: 0x001E7EF5
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002164 RID: 8548 RVA: 0x001E9D03 File Offset: 0x001E7F03
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x0400494C RID: 18764
		public CarController car;

		// Token: 0x0400494D RID: 18765
		private Renderer m_Renderer;
	}
}
