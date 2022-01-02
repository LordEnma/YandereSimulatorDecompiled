using System;
using UnityEngine;

namespace Aura2API
{
	// Token: 0x020005B3 RID: 1459
	public class DebugFps : MonoBehaviour
	{
		// Token: 0x060024BF RID: 9407 RVA: 0x001F97E0 File Offset: 0x001F79E0
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

		// Token: 0x060024C0 RID: 9408 RVA: 0x001F9864 File Offset: 0x001F7A64
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

		// Token: 0x04004C64 RID: 19556
		public float interval = 1f;

		// Token: 0x04004C65 RID: 19557
		private float _accumulationValue;

		// Token: 0x04004C66 RID: 19558
		private int _framesCount;

		// Token: 0x04004C67 RID: 19559
		private float _timestamp;

		// Token: 0x04004C68 RID: 19560
		private float _rawFps;

		// Token: 0x04004C69 RID: 19561
		private float _meanFps;
	}
}
