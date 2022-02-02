using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002465 RID: 9317 RVA: 0x001FA2BC File Offset: 0x001F84BC
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

		// Token: 0x04004C36 RID: 19510
		public SFXController.Sounds sound;

		// Token: 0x04004C37 RID: 19511
		public bool interupt;

		// Token: 0x04004C38 RID: 19512
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C39 RID: 19513
		[Reorderable]
		public AudioClips clips;
	}
}
