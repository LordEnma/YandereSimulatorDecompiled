using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052A RID: 1322
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021A5 RID: 8613 RVA: 0x001EBAD5 File Offset: 0x001E9CD5
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021A6 RID: 8614 RVA: 0x001EBAFE File Offset: 0x001E9CFE
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x040049B7 RID: 18871
		public GameObject wheel;

		// Token: 0x040049B8 RID: 18872
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x040049B9 RID: 18873
		private Vector3 m_Origin;
	}
}
