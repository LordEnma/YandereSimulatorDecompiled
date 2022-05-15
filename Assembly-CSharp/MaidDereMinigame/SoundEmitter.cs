using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AE RID: 1454
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x060024CB RID: 9419 RVA: 0x002035D0 File Offset: 0x002017D0
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

		// Token: 0x04004D5C RID: 19804
		public SFXController.Sounds sound;

		// Token: 0x04004D5D RID: 19805
		public bool interupt;

		// Token: 0x04004D5E RID: 19806
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004D5F RID: 19807
		[Reorderable]
		public AudioClips clips;
	}
}
