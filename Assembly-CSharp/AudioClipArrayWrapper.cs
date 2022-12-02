using System;
using UnityEngine;

[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	public AudioClipArrayWrapper(int size)
		: base(size)
	{
	}

	public AudioClipArrayWrapper(AudioClip[] elements)
		: base(elements)
	{
	}
}
