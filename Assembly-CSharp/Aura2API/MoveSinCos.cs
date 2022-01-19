using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B8 RID: 1464
	public class MoveSinCos : MonoBehaviour
	{
		// Token: 0x060024D4 RID: 9428 RVA: 0x001FB0FC File Offset: 0x001F92FC
		private void Start()
		{
			this._initialPosition = base.transform.position;
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x001FB110 File Offset: 0x001F9310
		private void Update()
		{
			Vector3 vector = this.sinDirection.normalized * Mathf.Sin(Time.time * this.sinSpeed + this.sinOffset) * this.sinAmplitude;
			Vector3 vector2 = this.cosDirection.normalized * Mathf.Cos(Time.time * this.cosSpeed + this.cosOffset) * this.cosAmplitude;
			vector = ((this.space == Space.World) ? vector : base.transform.localToWorldMatrix.MultiplyVector(vector));
			vector2 = ((this.space == Space.World) ? vector2 : base.transform.localToWorldMatrix.MultiplyVector(vector2));
			base.transform.position = this._initialPosition + vector + vector2;
		}

		// Token: 0x04004C92 RID: 19602
		private Vector3 _initialPosition;

		// Token: 0x04004C93 RID: 19603
		public float cosAmplitude;

		// Token: 0x04004C94 RID: 19604
		public Vector3 cosDirection = Vector3.right;

		// Token: 0x04004C95 RID: 19605
		public float cosOffset;

		// Token: 0x04004C96 RID: 19606
		public float cosSpeed;

		// Token: 0x04004C97 RID: 19607
		public float sinAmplitude;

		// Token: 0x04004C98 RID: 19608
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C99 RID: 19609
		public float sinOffset;

		// Token: 0x04004C9A RID: 19610
		public float sinSpeed;

		// Token: 0x04004C9B RID: 19611
		public Space space = Space.Self;
	}
}
