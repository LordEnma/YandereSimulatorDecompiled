using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002471 RID: 9329 RVA: 0x001FAC8C File Offset: 0x001F8E8C
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

		// Token: 0x04004C48 RID: 19528
		public SFXController.Sounds sound;

		// Token: 0x04004C49 RID: 19529
		public bool interupt;

		// Token: 0x04004C4A RID: 19530
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C4B RID: 19531
		[Reorderable]
		public AudioClips clips;
	}
}
