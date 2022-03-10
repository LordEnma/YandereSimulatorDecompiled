using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x06002480 RID: 9344 RVA: 0x001FC244 File Offset: 0x001FA444
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

		// Token: 0x04004C75 RID: 19573
		public SFXController.Sounds sound;

		// Token: 0x04004C76 RID: 19574
		public bool interupt;

		// Token: 0x04004C77 RID: 19575
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C78 RID: 19576
		[Reorderable]
		public AudioClips clips;
	}
}
