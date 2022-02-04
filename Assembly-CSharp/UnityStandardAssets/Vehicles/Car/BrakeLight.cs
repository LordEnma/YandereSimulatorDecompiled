using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051F RID: 1311
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x06002165 RID: 8549 RVA: 0x001EA00D File Offset: 0x001E820D
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002166 RID: 8550 RVA: 0x001EA01B File Offset: 0x001E821B
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004952 RID: 18770
		public CarController car;

		// Token: 0x04004953 RID: 18771
		private Renderer m_Renderer;
	}
}
