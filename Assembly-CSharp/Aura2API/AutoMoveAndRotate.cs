using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B2 RID: 1458
	public class AutoMoveAndRotate : MonoBehaviour
	{
		// Token: 0x060024BC RID: 9404 RVA: 0x001F9747 File Offset: 0x001F7947
		private void Start()
		{
			this.m_LastRealTime = Time.realtimeSinceStartup;
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x001F9754 File Offset: 0x001F7954
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

		// Token: 0x04004C60 RID: 19552
		public AutoMoveAndRotate.Vector3andSpace moveUnitsPerSecond;

		// Token: 0x04004C61 RID: 19553
		public AutoMoveAndRotate.Vector3andSpace rotateDegreesPerSecond;

		// Token: 0x04004C62 RID: 19554
		public bool ignoreTimescale;

		// Token: 0x04004C63 RID: 19555
		private float m_LastRealTime;

		// Token: 0x020006E4 RID: 1764
		[Serializable]
		public class Vector3andSpace
		{
			// Token: 0x040051D6 RID: 20950
			public Vector3 value;

			// Token: 0x040051D7 RID: 20951
			public Space space = Space.Self;
		}
	}
}
