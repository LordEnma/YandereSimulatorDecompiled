using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B5 RID: 1461
	public class DebugFps : MonoBehaviour
	{
		// Token: 0x060024CA RID: 9418 RVA: 0x001FA180 File Offset: 0x001F8380
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

		// Token: 0x060024CB RID: 9419 RVA: 0x001FA204 File Offset: 0x001F8404
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

		// Token: 0x04004C78 RID: 19576
		public float interval = 1f;

		// Token: 0x04004C79 RID: 19577
		private float _accumulationValue;

		// Token: 0x04004C7A RID: 19578
		private int _framesCount;

		// Token: 0x04004C7B RID: 19579
		private float _timestamp;

		// Token: 0x04004C7C RID: 19580
		private float _rawFps;

		// Token: 0x04004C7D RID: 19581
		private float _meanFps;
	}
}
