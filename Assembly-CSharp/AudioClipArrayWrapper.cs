using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F62 RID: 8034 RVA: 0x001BF177 File Offset: 0x001BD377
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x001BF180 File Offset: 0x001BD380
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
