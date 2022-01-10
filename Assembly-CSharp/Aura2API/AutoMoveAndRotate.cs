using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B4 RID: 1460
	public class AutoMoveAndRotate : MonoBehaviour
	{
		// Token: 0x060024C7 RID: 9415 RVA: 0x001FA0E7 File Offset: 0x001F82E7
		private void Start()
		{
			this.m_LastRealTime = Time.realtimeSinceStartup;
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x001FA0F4 File Offset: 0x001F82F4
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

		// Token: 0x04004C74 RID: 19572
		public AutoMoveAndRotate.Vector3andSpace moveUnitsPerSecond;

		// Token: 0x04004C75 RID: 19573
		public AutoMoveAndRotate.Vector3andSpace rotateDegreesPerSecond;

		// Token: 0x04004C76 RID: 19574
		public bool ignoreTimescale;

		// Token: 0x04004C77 RID: 19575
		private float m_LastRealTime;

		// Token: 0x020006E6 RID: 1766
		[Serializable]
		public class Vector3andSpace
		{
			// Token: 0x040051EA RID: 20970
			public Vector3 value;

			// Token: 0x040051EB RID: 20971
			public Space space = Space.Self;
		}
	}
}
