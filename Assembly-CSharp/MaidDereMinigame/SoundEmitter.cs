using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x060024CC RID: 9420 RVA: 0x00203B38 File Offset: 0x00201D38
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

		// Token: 0x04004D65 RID: 19813
		public SFXController.Sounds sound;

		// Token: 0x04004D66 RID: 19814
		public bool interupt;

		// Token: 0x04004D67 RID: 19815
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004D68 RID: 19816
		[Reorderable]
		public AudioClips clips;
	}
}
