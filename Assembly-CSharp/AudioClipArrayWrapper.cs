using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F19 RID: 7961 RVA: 0x001B886B File Offset: 0x001B6A6B
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x001B8874 File Offset: 0x001B6A74
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
