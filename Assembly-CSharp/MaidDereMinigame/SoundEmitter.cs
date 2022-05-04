using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x060024C1 RID: 9409 RVA: 0x00201F80 File Offset: 0x00200180
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

		// Token: 0x04004D35 RID: 19765
		public SFXController.Sounds sound;

		// Token: 0x04004D36 RID: 19766
		public bool interupt;

		// Token: 0x04004D37 RID: 19767
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004D38 RID: 19768
		[Reorderable]
		public AudioClips clips;
	}
}
