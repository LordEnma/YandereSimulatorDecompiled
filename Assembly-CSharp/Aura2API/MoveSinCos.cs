using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B5 RID: 1461
	public class MoveSinCos : MonoBehaviour
	{
		// Token: 0x060024C4 RID: 9412 RVA: 0x001F949C File Offset: 0x001F769C
		private void Start()
		{
			this._initialPosition = base.transform.position;
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x001F94B0 File Offset: 0x001F76B0
		private void Update()
		{
			Vector3 vector = this.sinDirection.normalized * Mathf.Sin(Time.time * this.sinSpeed + this.sinOffset) * this.sinAmplitude;
			Vector3 vector2 = this.cosDirection.normalized * Mathf.Cos(Time.time * this.cosSpeed + this.cosOffset) * this.cosAmplitude;
			vector = ((this.space == Space.World) ? vector : base.transform.localToWorldMatrix.MultiplyVector(vector));
			vector2 = ((this.space == Space.World) ? vector2 : base.transform.localToWorldMatrix.MultiplyVector(vector2));
			base.transform.position = this._initialPosition + vector + vector2;
		}

		// Token: 0x04004C6E RID: 19566
		private Vector3 _initialPosition;

		// Token: 0x04004C6F RID: 19567
		public float cosAmplitude;

		// Token: 0x04004C70 RID: 19568
		public Vector3 cosDirection = Vector3.right;

		// Token: 0x04004C71 RID: 19569
		public float cosOffset;

		// Token: 0x04004C72 RID: 19570
		public float cosSpeed;

		// Token: 0x04004C73 RID: 19571
		public float sinAmplitude;

		// Token: 0x04004C74 RID: 19572
		public Vector3 sinDirection = Vector3.up;

		// Token: 0x04004C75 RID: 19573
		public float sinOffset;

		// Token: 0x04004C76 RID: 19574
		public float sinSpeed;

		// Token: 0x04004C77 RID: 19575
		public Space space = Space.Self;
	}
}
