using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B8 RID: 1464
	public class SinRotationOffset : MonoBehaviour
	{
		// Token: 0x060024D5 RID: 9429 RVA: 0x001FA537 File Offset: 0x001F8737
		private void Start()
		{
			this._initialRotation = ((this.space == Space.Self) ? base.transform.localRotation : base.transform.rotation);
		}

		// Token: 0x060024D6 RID: 9430 RVA: 0x001FA560 File Offset: 0x001F8760
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

		// Token: 0x04004C95 RID: 19605
		private Quaternion _initialRotation;

		// Token: 0x04004C96 RID: 19606
		public float sinAmplitude = 15f;

		// Token: 0x04004C97 RID: 19607
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C98 RID: 19608
		public float sinOffset;

		// Token: 0x04004C99 RID: 19609
		public float sinSpeed = 1f;

		// Token: 0x04004C9A RID: 19610
		public Space space = Space.Self;
	}
}
