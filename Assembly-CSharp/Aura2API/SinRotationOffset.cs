using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B6 RID: 1462
	public class SinRotationOffset : MonoBehaviour
	{
		// Token: 0x060024CA RID: 9418 RVA: 0x001F9B97 File Offset: 0x001F7D97
		private void Start()
		{
			this._initialRotation = ((this.space == Space.Self) ? base.transform.localRotation : base.transform.rotation);
		}

		// Token: 0x060024CB RID: 9419 RVA: 0x001F9BC0 File Offset: 0x001F7DC0
		private void Update()
		{
			Quaternion rhs = Quaternion.AngleAxis(this.sinAmplitude * Mathf.Sin(Time.time * this.sinSpeed + this.sinOffset), this.sinDirection);
			if (this.space == Space.Self)
			{
				base.transform.localRotation = this._initialRotation * rhs;
				return;
			}
			base.transform.rotation = this._initialRotation * rhs;
		}

		// Token: 0x04004C81 RID: 19585
		private Quaternion _initialRotation;

		// Token: 0x04004C82 RID: 19586
		public float sinAmplitude = 15f;

		// Token: 0x04004C83 RID: 19587
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C84 RID: 19588
		public float sinOffset;

		// Token: 0x04004C85 RID: 19589
		public float sinSpeed = 1f;

		// Token: 0x04004C86 RID: 19590
		public Space space = Space.Self;
	}
}
