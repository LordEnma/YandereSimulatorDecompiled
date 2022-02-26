using System;
using UnityEngine;

// Token: 0x02000493 RID: 1171
public static class AudioClipPlayer
{
	// Token: 0x06001F32 RID: 7986 RVA: 0x001B9A64 File Offset: 0x001B7C64
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

	// Token: 0x06001F33 RID: 7987 RVA: 0x001B9B04 File Offset: 0x001B7D04
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

	// Token: 0x06001F34 RID: 7988 RVA: 0x001B9BB0 File Offset: 0x001B7DB0
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

	// Token: 0x06001F35 RID: 7989 RVA: 0x001B9C30 File Offset: 0x001B7E30
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

	// Token: 0x06001F36 RID: 7990 RVA: 0x001B9CAC File Offset: 0x001B7EAC
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

	// Token: 0x06001F37 RID: 7991 RVA: 0x001B9D1D File Offset: 0x001B7F1D
	public static void Play2D(AudioClip clip, Vector3 position)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
	}

	// Token: 0x06001F38 RID: 7992 RVA: 0x001B9D60 File Offset: 0x001B7F60
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
