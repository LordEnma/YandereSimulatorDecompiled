using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x060024B7 RID: 9399 RVA: 0x002009A8 File Offset: 0x001FEBA8
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

		// Token: 0x04004D1C RID: 19740
		public SFXController.Sounds sound;

		// Token: 0x04004D1D RID: 19741
		public bool interupt;

		// Token: 0x04004D1E RID: 19742
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004D1F RID: 19743
		[Reorderable]
		public AudioClips clips;
	}
}
