using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000536 RID: 1334
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021EB RID: 8683 RVA: 0x001F17F1 File Offset: 0x001EF9F1
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001F181A File Offset: 0x001EFA1A
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004A8B RID: 19083
		public GameObject wheel;

		// Token: 0x04004A8C RID: 19084
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004A8D RID: 19085
		private Vector3 m_Origin;
	}
}
