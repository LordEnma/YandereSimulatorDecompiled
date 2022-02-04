using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002467 RID: 9319 RVA: 0x001FA5D4 File Offset: 0x001F87D4
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

		// Token: 0x04004C3C RID: 19516
		public SFXController.Sounds sound;

		// Token: 0x04004C3D RID: 19517
		public bool interupt;

		// Token: 0x04004C3E RID: 19518
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C3F RID: 19519
		[Reorderable]
		public AudioClips clips;
	}
}
