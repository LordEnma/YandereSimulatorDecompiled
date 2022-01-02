using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002454 RID: 9300 RVA: 0x001F83AC File Offset: 0x001F65AC
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

		// Token: 0x04004C10 RID: 19472
		public SFXController.Sounds sound;

		// Token: 0x04004C11 RID: 19473
		public bool interupt;

		// Token: 0x04004C12 RID: 19474
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C13 RID: 19475
		[Reorderable]
		public AudioClips clips;
	}
}
