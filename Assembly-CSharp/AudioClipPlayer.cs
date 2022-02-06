using System;
using UnityEngine;

// Token: 0x02000491 RID: 1169
public static class AudioClipPlayer
{
	// Token: 0x06001F22 RID: 7970 RVA: 0x001B8AC4 File Offset: 0x001B6CC4
	public static void Play(AudioClip clip, Vector3 position, float minDistance, float maxDistance, out GameObject clipOwner, float playerY)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = minDistance;
		audioSource.maxDistance = maxDistance;
		audioSource.spatialBlend = 1f;
		clipOwner = gameObject;
		float y = gameObject.transform.position.y;
		audioSource.volume = ((playerY < y - 2f) ? 0f : 1f);
	}

	// Token: 0x06001F23 RID: 7971 RVA: 0x001B8B64 File Offset: 0x001B6D64
	public static void PlayAttached(AudioClip clip, Vector3 position, Transform attachment, float minDistance, float maxDistance, out GameObject clipOwner, float playerY)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		gameObject.transform.parent = attachment;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = minDistance;
		audioSource.maxDistance = maxDistance;
		audioSource.spatialBlend = 1f;
		clipOwner = gameObject;
		float y = gameObject.transform.position.y;
		audioSource.volume = ((playerY < y - 2f) ? 0f : 1f);
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x001B8C10 File Offset: 0x001B6E10
	public static void PlayAttached(AudioClip clip, Transform attachment, float minDistance, float maxDistance)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.parent = attachment;
		gameObject.transform.localPosition = Vector3.zero;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = minDistance;
		audioSource.maxDistance = maxDistance;
		audioSource.spatialBlend = 1f;
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B8C90 File Offset: 0x001B6E90
	public static void Play(AudioClip clip, Vector3 position, float minDistance, float maxDistance, out GameObject clipOwner, out float clipLength)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		clipLength = clip.length;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = minDistance;
		audioSource.maxDistance = maxDistance;
		audioSource.spatialBlend = 1f;
		clipOwner = gameObject;
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B8D0C File Offset: 0x001B6F0C
	public static void Play(AudioClip clip, Vector3 position, float minDistance, float maxDistance, out GameObject clipOwner)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = minDistance;
		audioSource.maxDistance = maxDistance;
		audioSource.spatialBlend = 1f;
		clipOwner = gameObject;
	}

	// Token: 0x06001F27 RID: 7975 RVA: 0x001B8D7D File Offset: 0x001B6F7D
	public static void Play2D(AudioClip clip, Vector3 position)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x001B8DC0 File Offset: 0x001B6FC0
	public static void Play2D(AudioClip clip, Vector3 position, float pitch)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.pitch = pitch;
	}
}
