using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002440 RID: 9280 RVA: 0x001F6688 File Offset: 0x001F4888
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

		// Token: 0x04004BC8 RID: 19400
		public SFXController.Sounds sound;

		// Token: 0x04004BC9 RID: 19401
		public bool interupt;

		// Token: 0x04004BCA RID: 19402
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004BCB RID: 19403
		[Reorderable]
		public AudioClips clips;
	}
}
