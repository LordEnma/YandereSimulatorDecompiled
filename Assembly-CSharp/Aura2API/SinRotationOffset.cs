using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B4 RID: 1460
	public class SinRotationOffset : MonoBehaviour
	{
		// Token: 0x060024B6 RID: 9398 RVA: 0x001F7E73 File Offset: 0x001F6073
		private void Start()
		{
			this._initialRotation = ((this.space == Space.Self) ? base.transform.localRotation : base.transform.rotation);
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x001F7E9C File Offset: 0x001F609C
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

		// Token: 0x04004C39 RID: 19513
		private Quaternion _initialRotation;

		// Token: 0x04004C3A RID: 19514
		public float sinAmplitude = 15f;

		// Token: 0x04004C3B RID: 19515
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C3C RID: 19516
		public float sinOffset;

		// Token: 0x04004C3D RID: 19517
		public float sinSpeed = 1f;

		// Token: 0x04004C3E RID: 19518
		public Space space = Space.Self;
	}
}
