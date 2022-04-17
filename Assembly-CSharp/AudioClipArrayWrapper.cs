using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F59 RID: 8025 RVA: 0x001BDDBB File Offset: 0x001BBFBB
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F5A RID: 8026 RVA: 0x001BDDC4 File Offset: 0x001BBFC4
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
