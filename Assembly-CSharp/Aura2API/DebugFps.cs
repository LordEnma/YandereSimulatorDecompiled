using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B1 RID: 1457
	public class DebugFps : MonoBehaviour
	{
		// Token: 0x060024AB RID: 9387 RVA: 0x001F7ABC File Offset: 0x001F5CBC
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

		// Token: 0x060024AC RID: 9388 RVA: 0x001F7B40 File Offset: 0x001F5D40
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

		// Token: 0x04004C1C RID: 19484
		public float interval = 1f;

		// Token: 0x04004C1D RID: 19485
		private float _accumulationValue;

		// Token: 0x04004C1E RID: 19486
		private int _framesCount;

		// Token: 0x04004C1F RID: 19487
		private float _timestamp;

		// Token: 0x04004C20 RID: 19488
		private float _rawFps;

		// Token: 0x04004C21 RID: 19489
		private float _meanFps;
	}
}
