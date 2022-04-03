using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F4B RID: 8011 RVA: 0x001BCED7 File Offset: 0x001BB0D7
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F4C RID: 8012 RVA: 0x001BCEE0 File Offset: 0x001BB0E0
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
