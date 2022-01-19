using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B9 RID: 1465
	public class SinRotationOffset : MonoBehaviour
	{
		// Token: 0x060024D7 RID: 9431 RVA: 0x001FB207 File Offset: 0x001F9407
		private void Start()
		{
			this._initialRotation = ((this.space == Space.Self) ? base.transform.localRotation : base.transform.rotation);
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x001FB230 File Offset: 0x001F9430
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

		// Token: 0x04004C9C RID: 19612
		private Quaternion _initialRotation;

		// Token: 0x04004C9D RID: 19613
		public float sinAmplitude = 15f;

		// Token: 0x04004C9E RID: 19614
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C9F RID: 19615
		public float sinOffset;

		// Token: 0x04004CA0 RID: 19616
		public float sinSpeed = 1f;

		// Token: 0x04004CA1 RID: 19617
		public Space space = Space.Self;
	}
}
