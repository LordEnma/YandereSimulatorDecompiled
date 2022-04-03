using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x060024A8 RID: 9384 RVA: 0x001FFA1C File Offset: 0x001FDC1C
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

		// Token: 0x04004D06 RID: 19718
		public SFXController.Sounds sound;

		// Token: 0x04004D07 RID: 19719
		public bool interupt;

		// Token: 0x04004D08 RID: 19720
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004D09 RID: 19721
		[Reorderable]
		public AudioClips clips;
	}
}
