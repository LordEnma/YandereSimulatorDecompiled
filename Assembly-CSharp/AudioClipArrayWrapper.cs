using System;
using UnityEngine;

// Token: 0x02000490 RID: 1168
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F2F RID: 7983 RVA: 0x001BA1CB File Offset: 0x001B83CB
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F30 RID: 7984 RVA: 0x001BA1D4 File Offset: 0x001B83D4
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
