using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051C RID: 1308
	public class BrakeLight : MonoBehaviour
	{
		// Token: 0x06002152 RID: 8530 RVA: 0x001E7DE5 File Offset: 0x001E5FE5
		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		// Token: 0x06002153 RID: 8531 RVA: 0x001E7DF3 File Offset: 0x001E5FF3
		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}

		// Token: 0x04004926 RID: 18726
		public CarController car;

		// Token: 0x04004927 RID: 18727
		private Renderer m_Renderer;
	}
}
