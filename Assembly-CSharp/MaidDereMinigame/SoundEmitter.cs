using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x060024B0 RID: 9392 RVA: 0x001FFF4C File Offset: 0x001FE14C
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

		// Token: 0x04004D0A RID: 19722
		public SFXController.Sounds sound;

		// Token: 0x04004D0B RID: 19723
		public bool interupt;

		// Token: 0x04004D0C RID: 19724
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004D0D RID: 19725
		[Reorderable]
		public AudioClips clips;
	}
}
