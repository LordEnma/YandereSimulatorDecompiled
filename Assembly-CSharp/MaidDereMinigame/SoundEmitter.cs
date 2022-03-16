using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002498 RID: 9368 RVA: 0x001FE1AC File Offset: 0x001FC3AC
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

		// Token: 0x04004CD4 RID: 19668
		public SFXController.Sounds sound;

		// Token: 0x04004CD5 RID: 19669
		public bool interupt;

		// Token: 0x04004CD6 RID: 19670
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004CD7 RID: 19671
		[Reorderable]
		public AudioClips clips;
	}
}
