using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B0 RID: 1456
	public class AutoMoveAndRotate : MonoBehaviour
	{
		// Token: 0x060024A8 RID: 9384 RVA: 0x001F7A23 File Offset: 0x001F5C23
		private void Start()
		{
			this.m_LastRealTime = Time.realtimeSinceStartup;
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x001F7A30 File Offset: 0x001F5C30
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

		// Token: 0x04004C18 RID: 19480
		public AutoMoveAndRotate.Vector3andSpace moveUnitsPerSecond;

		// Token: 0x04004C19 RID: 19481
		public AutoMoveAndRotate.Vector3andSpace rotateDegreesPerSecond;

		// Token: 0x04004C1A RID: 19482
		public bool ignoreTimescale;

		// Token: 0x04004C1B RID: 19483
		private float m_LastRealTime;

		// Token: 0x020006E1 RID: 1761
		[Serializable]
		public class Vector3andSpace
		{
			// Token: 0x04005182 RID: 20866
			public Vector3 value;

			// Token: 0x04005183 RID: 20867
			public Space space = Space.Self;
		}
	}
}
