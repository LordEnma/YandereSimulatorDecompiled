using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000530 RID: 1328
	public class Suspension : MonoBehaviour
	{
		// Token: 0x060021CC RID: 8652 RVA: 0x001EEFF5 File Offset: 0x001ED1F5
		private void Start()
		{
			this.m_TargetOriginalPosition = this.wheel.transform.localPosition;
			this.m_Origin = base.transform.localPosition;
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x001EF01E File Offset: 0x001ED21E
		private void Update()
		{
			base.transform.localPosition = this.m_Origin + (this.wheel.transform.localPosition - this.m_TargetOriginalPosition);
		}

		// Token: 0x04004A43 RID: 19011
		public GameObject wheel;

		// Token: 0x04004A44 RID: 19012
		private Vector3 m_TargetOriginalPosition;

		// Token: 0x04004A45 RID: 19013
		private Vector3 m_Origin;
	}
}
