using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052E RID: 1326
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x060021C9 RID: 8649 RVA: 0x001F2FB9 File Offset: 0x001F11B9
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x001F2FC7 File Offset: 0x001F11C7
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004A6F RID: 19055
		public CarController car;

		// Token: 0x04004A70 RID: 19056
		private Renderer m_Renderer;
	}
}
