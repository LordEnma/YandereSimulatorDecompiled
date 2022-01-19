using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002461 RID: 9313 RVA: 0x001F9A1C File Offset: 0x001F7C1C
		public AudioSource GetSource()
		{
			for (int i = 0; i < this.sources.Count; i++)
			{
				if (!this.sources[i].isPlaying)
				{
					return this.sources[i];
				}
			}
			return this.sources[0];
		}

		// Token: 0x04004C2B RID: 19499
		public SFXController.Sounds sound;

		// Token: 0x04004C2C RID: 19500
		public bool interupt;

		// Token: 0x04004C2D RID: 19501
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C2E RID: 19502
		[Reorderable]
		public AudioClips clips;
	}
}
