using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B5 RID: 1461
	public class MoveSinCos : MonoBehaviour
	{
		// Token: 0x060024C7 RID: 9415 RVA: 0x001F9A8C File Offset: 0x001F7C8C
		private void Start()
		{
			this._initialPosition = base.transform.position;
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001F9AA0 File Offset: 0x001F7CA0
		private void Update()
		{
			Vector3 vector = this.sinDirection.normalized * Mathf.Sin(Time.time * this.sinSpeed + this.sinOffset) * this.sinAmplitude;
			Vector3 vector2 = this.cosDirection.normalized * Mathf.Cos(Time.time * this.cosSpeed + this.cosOffset) * this.cosAmplitude;
			vector = ((this.space == Space.World) ? vector : base.transform.localToWorldMatrix.MultiplyVector(vector));
			vector2 = ((this.space == Space.World) ? vector2 : base.transform.localToWorldMatrix.MultiplyVector(vector2));
			base.transform.position = this._initialPosition + vector + vector2;
		}

		// Token: 0x04004C77 RID: 19575
		private Vector3 _initialPosition;

		// Token: 0x04004C78 RID: 19576
		public float cosAmplitude;

		// Token: 0x04004C79 RID: 19577
		public Vector3 cosDirection = Vector3.right;

		// Token: 0x04004C7A RID: 19578
		public float cosOffset;

		// Token: 0x04004C7B RID: 19579
		public float cosSpeed;

		// Token: 0x04004C7C RID: 19580
		public float sinAmplitude;

		// Token: 0x04004C7D RID: 19581
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C7E RID: 19582
		public float sinOffset;

		// Token: 0x04004C7F RID: 19583
		public float sinSpeed;

		// Token: 0x04004C80 RID: 19584
		public Space space = Space.Self;
	}
}
