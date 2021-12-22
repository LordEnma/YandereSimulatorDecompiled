using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B6 RID: 1462
	public class SinRotationOffset : MonoBehaviour
	{
		// Token: 0x060024C7 RID: 9415 RVA: 0x001F95A7 File Offset: 0x001F77A7
		private void Start()
		{
			this._initialRotation = ((this.space == Space.Self) ? base.transform.localRotation : base.transform.rotation);
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001F95D0 File Offset: 0x001F77D0
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

		// Token: 0x04004C78 RID: 19576
		private Quaternion _initialRotation;

		// Token: 0x04004C79 RID: 19577
		public float sinAmplitude = 15f;

		// Token: 0x04004C7A RID: 19578
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C7B RID: 19579
		public float sinOffset;

		// Token: 0x04004C7C RID: 19580
		public float sinSpeed = 1f;

		// Token: 0x04004C7D RID: 19581
		public Space space = Space.Self;
	}
}
