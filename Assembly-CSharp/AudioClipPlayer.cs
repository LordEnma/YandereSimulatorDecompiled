using System;
using UnityEngine;

// Token: 0x0200049C RID: 1180
public static class AudioClipPlayer
{
	// Token: 0x06001F73 RID: 8051 RVA: 0x001C08C0 File Offset: 0x001BEAC0
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

	// Token: 0x06001F74 RID: 8052 RVA: 0x001C0960 File Offset: 0x001BEB60
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

	// Token: 0x06001F75 RID: 8053 RVA: 0x001C0A0C File Offset: 0x001BEC0C
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

	// Token: 0x06001F76 RID: 8054 RVA: 0x001C0A8C File Offset: 0x001BEC8C
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

	// Token: 0x06001F77 RID: 8055 RVA: 0x001C0B08 File Offset: 0x001BED08
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

	// Token: 0x06001F78 RID: 8056 RVA: 0x001C0B79 File Offset: 0x001BED79
	public static void Play2D(AudioClip clip, Vector3 position)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
	}

	// Token: 0x06001F79 RID: 8057 RVA: 0x001C0BBC File Offset: 0x001BEDBC
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
