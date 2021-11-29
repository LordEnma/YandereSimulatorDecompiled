using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B3 RID: 1459
	public class MoveSinCos : MonoBehaviour
	{
		// Token: 0x060024B3 RID: 9395 RVA: 0x001F7D68 File Offset: 0x001F5F68
		private void Start()
		{
			this._initialPosition = base.transform.position;
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x001F7D7C File Offset: 0x001F5F7C
		private void Update()
		{
			Vector3 vector = this.sinDirection.normalized * Mathf.Sin(Time.time * this.sinSpeed + this.sinOffset) * this.sinAmplitude;
			Vector3 vector2 = this.cosDirection.normalized * Mathf.Cos(Time.time * this.cosSpeed + this.cosOffset) * this.cosAmplitude;
			vector = ((this.space == Space.World) ? vector : base.transform.localToWorldMatrix.MultiplyVector(vector));
			vector2 = ((this.space == Space.World) ? vector2 : base.transform.localToWorldMatrix.MultiplyVector(vector2));
			base.transform.position = this._initialPosition + vector + vector2;
		}

		// Token: 0x04004C2F RID: 19503
		private Vector3 _initialPosition;

		// Token: 0x04004C30 RID: 19504
		public float cosAmplitude;

		// Token: 0x04004C31 RID: 19505
		public Vector3 cosDirection = Vector3.right;

		// Token: 0x04004C32 RID: 19506
		public float cosOffset;

		// Token: 0x04004C33 RID: 19507
		public float cosSpeed;

		// Token: 0x04004C34 RID: 19508
		public float sinAmplitude;

		// Token: 0x04004C35 RID: 19509
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C36 RID: 19510
		public float sinOffset;

		// Token: 0x04004C37 RID: 19511
		public float sinSpeed;

		// Token: 0x04004C38 RID: 19512
		public Space space = Space.Self;
	}
}
