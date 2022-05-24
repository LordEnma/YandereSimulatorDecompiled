using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052E RID: 1326
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x060021CA RID: 8650 RVA: 0x001F3521 File Offset: 0x001F1721
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x001F352F File Offset: 0x001F172F
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004A78 RID: 19064
		public CarController car;

		// Token: 0x04004A79 RID: 19065
		private Renderer m_Renderer;
	}
}
