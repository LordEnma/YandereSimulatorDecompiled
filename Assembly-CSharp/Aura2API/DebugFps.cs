using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B6 RID: 1462
	public class DebugFps : MonoBehaviour
	{
		// Token: 0x060024CC RID: 9420 RVA: 0x001FAE50 File Offset: 0x001F9050
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

		// Token: 0x060024CD RID: 9421 RVA: 0x001FAED4 File Offset: 0x001F90D4
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

		// Token: 0x04004C7F RID: 19583
		public float interval = 1f;

		// Token: 0x04004C80 RID: 19584
		private float _accumulationValue;

		// Token: 0x04004C81 RID: 19585
		private int _framesCount;

		// Token: 0x04004C82 RID: 19586
		private float _timestamp;

		// Token: 0x04004C83 RID: 19587
		private float _rawFps;

		// Token: 0x04004C84 RID: 19588
		private float _meanFps;
	}
}
