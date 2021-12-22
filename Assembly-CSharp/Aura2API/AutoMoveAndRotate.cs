using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B2 RID: 1458
	public class AutoMoveAndRotate : MonoBehaviour
	{
		// Token: 0x060024B9 RID: 9401 RVA: 0x001F9157 File Offset: 0x001F7357
		private void Start()
		{
			this.m_LastRealTime = Time.realtimeSinceStartup;
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x001F9164 File Offset: 0x001F7364
		private void Update()
		{
			float d = Time.deltaTime;
			if (this.ignoreTimescale)
			{
				d = Time.realtimeSinceStartup - this.m_LastRealTime;
				this.m_LastRealTime = Time.realtimeSinceStartup;
			}
			base.transform.Translate(this.moveUnitsPerSecond.value * d, this.moveUnitsPerSecond.space);
			base.transform.Rotate(this.rotateDegreesPerSecond.value * d, this.rotateDegreesPerSecond.space);
		}

		// Token: 0x04004C57 RID: 19543
		public AutoMoveAndRotate.Vector3andSpace moveUnitsPerSecond;

		// Token: 0x04004C58 RID: 19544
		public AutoMoveAndRotate.Vector3andSpace rotateDegreesPerSecond;

		// Token: 0x04004C59 RID: 19545
		public bool ignoreTimescale;

		// Token: 0x04004C5A RID: 19546
		private float m_LastRealTime;

		// Token: 0x020006E4 RID: 1764
		[Serializable]
		public class Vector3andSpace
		{
			// Token: 0x040051CD RID: 20941
			public Vector3 value;

			// Token: 0x040051CE RID: 20942
			public Space space = Space.Self;
		}
	}
}
