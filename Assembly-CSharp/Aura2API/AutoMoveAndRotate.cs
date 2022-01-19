using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B5 RID: 1461
	public class AutoMoveAndRotate : MonoBehaviour
	{
		// Token: 0x060024C9 RID: 9417 RVA: 0x001FADB7 File Offset: 0x001F8FB7
		private void Start()
		{
			this.m_LastRealTime = Time.realtimeSinceStartup;
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x001FADC4 File Offset: 0x001F8FC4
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

		// Token: 0x04004C7B RID: 19579
		public AutoMoveAndRotate.Vector3andSpace moveUnitsPerSecond;

		// Token: 0x04004C7C RID: 19580
		public AutoMoveAndRotate.Vector3andSpace rotateDegreesPerSecond;

		// Token: 0x04004C7D RID: 19581
		public bool ignoreTimescale;

		// Token: 0x04004C7E RID: 19582
		private float m_LastRealTime;

		// Token: 0x020006E7 RID: 1767
		[Serializable]
		public class Vector3andSpace
		{
			// Token: 0x040051F1 RID: 20977
			public Vector3 value;

			// Token: 0x040051F2 RID: 20978
			public Space space = Space.Self;
		}
	}
}
