using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B7 RID: 1463
	public class MoveSinCos : MonoBehaviour
	{
		// Token: 0x060024D2 RID: 9426 RVA: 0x001FA42C File Offset: 0x001F862C
		private void Start()
		{
			this._initialPosition = base.transform.position;
		}

		// Token: 0x060024D3 RID: 9427 RVA: 0x001FA440 File Offset: 0x001F8640
		private void Update()
		{
			Vector3 vector = this.sinDirection.normalized * Mathf.Sin(Time.time * this.sinSpeed + this.sinOffset) * this.sinAmplitude;
			Vector3 vector2 = this.cosDirection.normalized * Mathf.Cos(Time.time * this.cosSpeed + this.cosOffset) * this.cosAmplitude;
			vector = ((this.space == Space.World) ? vector : base.transform.localToWorldMatrix.MultiplyVector(vector));
			vector2 = ((this.space == Space.World) ? vector2 : base.transform.localToWorldMatrix.MultiplyVector(vector2));
			base.transform.position = this._initialPosition + vector + vector2;
		}

		// Token: 0x04004C8B RID: 19595
		private Vector3 _initialPosition;

		// Token: 0x04004C8C RID: 19596
		public float cosAmplitude;

		// Token: 0x04004C8D RID: 19597
		public Vector3 cosDirection = Vector3.right;

		// Token: 0x04004C8E RID: 19598
		public float cosOffset;

		// Token: 0x04004C8F RID: 19599
		public float cosSpeed;

		// Token: 0x04004C90 RID: 19600
		public float sinAmplitude;

		// Token: 0x04004C91 RID: 19601
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C92 RID: 19602
		public float sinOffset;

		// Token: 0x04004C93 RID: 19603
		public float sinSpeed;

		// Token: 0x04004C94 RID: 19604
		public Space space = Space.Self;
	}
}
