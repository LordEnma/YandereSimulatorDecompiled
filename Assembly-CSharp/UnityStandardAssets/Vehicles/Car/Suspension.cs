using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000536 RID: 1334
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021E4 RID: 8676 RVA: 0x001F0D95 File Offset: 0x001EEF95
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001F0DBE File Offset: 0x001EEFBE
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004A79 RID: 19065
		public GameObject wheel;

		// Token: 0x04004A7A RID: 19066
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004A7B RID: 19067
		private Vector3 m_Origin;
	}
}
