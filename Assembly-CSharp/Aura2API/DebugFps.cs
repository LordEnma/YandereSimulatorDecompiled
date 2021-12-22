using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B3 RID: 1459
	public class DebugFps : MonoBehaviour
	{
		// Token: 0x060024BC RID: 9404 RVA: 0x001F91F0 File Offset: 0x001F73F0
		private void Update()
		{
			if (Time.time - this._timestamp > this.interval)
			{
				this._meanFps = this._accumulationValue / (float)this._framesCount;
				this._timestamp = Time.time;
				this._framesCount = 0;
				this._accumulationValue = 0f;
			}
			this._framesCount++;
			this._rawFps = 1f / Time.deltaTime;
			this._accumulationValue += this._rawFps;
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x001F9274 File Offset: 0x001F7474
		private void OnGUI()
		{
			GUI.color = Color.white;
			GUI.Label(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), string.Concat(new string[]
			{
				"Mean FPS over ",
				this.interval.ToString(),
				" second(s) = ",
				this._meanFps.ToString(),
				"\nRaw FPS = ",
				this._rawFps.ToString()
			}));
		}

		// Token: 0x04004C5B RID: 19547
		public float interval = 1f;

		// Token: 0x04004C5C RID: 19548
		private float _accumulationValue;

		// Token: 0x04004C5D RID: 19549
		private int _framesCount;

		// Token: 0x04004C5E RID: 19550
		private float _timestamp;

		// Token: 0x04004C5F RID: 19551
		private float _rawFps;

		// Token: 0x04004C60 RID: 19552
		private float _meanFps;
	}
}
