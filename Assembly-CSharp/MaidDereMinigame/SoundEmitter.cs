using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002451 RID: 9297 RVA: 0x001F7DBC File Offset: 0x001F5FBC
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

		// Token: 0x04004C07 RID: 19463
		public SFXController.Sounds sound;

		// Token: 0x04004C08 RID: 19464
		public bool interupt;

		// Token: 0x04004C09 RID: 19465
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C0A RID: 19466
		[Reorderable]
		public AudioClips clips;
	}
}
