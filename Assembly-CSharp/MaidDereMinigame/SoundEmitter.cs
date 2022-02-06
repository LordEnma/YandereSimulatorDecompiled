using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x0600246A RID: 9322 RVA: 0x001FA7D8 File Offset: 0x001F89D8
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

		// Token: 0x04004C3F RID: 19519
		public SFXController.Sounds sound;

		// Token: 0x04004C40 RID: 19520
		public bool interupt;

		// Token: 0x04004C41 RID: 19521
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C42 RID: 19522
		[Reorderable]
		public AudioClips clips;
	}
}
