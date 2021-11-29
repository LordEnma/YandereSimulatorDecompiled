using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public static class AudioClipPlayer
{
	// Token: 0x06001F01 RID: 7937 RVA: 0x001B578C File Offset: 0x001B398C
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

	// Token: 0x06001F02 RID: 7938 RVA: 0x001B582C File Offset: 0x001B3A2C
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

	// Token: 0x06001F03 RID: 7939 RVA: 0x001B58D8 File Offset: 0x001B3AD8
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

	// Token: 0x06001F04 RID: 7940 RVA: 0x001B5958 File Offset: 0x001B3B58
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

	// Token: 0x06001F05 RID: 7941 RVA: 0x001B59D4 File Offset: 0x001B3BD4
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

	// Token: 0x06001F06 RID: 7942 RVA: 0x001B5A45 File Offset: 0x001B3C45
	public static void Play2D(AudioClip clip, Vector3 position)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
	}

	// Token: 0x06001F07 RID: 7943 RVA: 0x001B5A88 File Offset: 0x001B3C88
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
