using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F1C RID: 7964 RVA: 0x001B8A8B File Offset: 0x001B6C8B
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F1D RID: 7965 RVA: 0x001B8A94 File Offset: 0x001B6C94
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
