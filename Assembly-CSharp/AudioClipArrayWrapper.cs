using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F17 RID: 7959 RVA: 0x001B855F File Offset: 0x001B675F
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x001B8568 File Offset: 0x001B6768
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
