using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F63 RID: 8035 RVA: 0x001BF273 File Offset: 0x001BD473
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x001BF27C File Offset: 0x001BD47C
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
