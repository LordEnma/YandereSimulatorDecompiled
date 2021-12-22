using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F05 RID: 7941 RVA: 0x001B650F File Offset: 0x001B470F
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F06 RID: 7942 RVA: 0x001B6518 File Offset: 0x001B4718
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
