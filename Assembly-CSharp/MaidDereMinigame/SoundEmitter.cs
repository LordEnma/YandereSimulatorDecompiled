using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x0600245F RID: 9311 RVA: 0x001F8D4C File Offset: 0x001F6F4C
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

		// Token: 0x04004C24 RID: 19492
		public SFXController.Sounds sound;

		// Token: 0x04004C25 RID: 19493
		public bool interupt;

		// Token: 0x04004C26 RID: 19494
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C27 RID: 19495
		[Reorderable]
		public AudioClips clips;
	}
}
