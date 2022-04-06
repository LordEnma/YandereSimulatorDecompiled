using System;
using UnityEngine;

// Token: 0x0200049A RID: 1178
public static class AudioClipPlayer
{
	// Token: 0x06001F59 RID: 8025 RVA: 0x001BD418 File Offset: 0x001BB618
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

	// Token: 0x06001F5A RID: 8026 RVA: 0x001BD4B8 File Offset: 0x001BB6B8
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

	// Token: 0x06001F5B RID: 8027 RVA: 0x001BD564 File Offset: 0x001BB764
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

	// Token: 0x06001F5C RID: 8028 RVA: 0x001BD5E4 File Offset: 0x001BB7E4
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

	// Token: 0x06001F5D RID: 8029 RVA: 0x001BD660 File Offset: 0x001BB860
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

	// Token: 0x06001F5E RID: 8030 RVA: 0x001BD6D1 File Offset: 0x001BB8D1
	public static void Play2D(AudioClip clip, Vector3 position)
	{
		GameObject gameObject = new GameObject("AudioClip_" + clip.name);
		gameObject.transform.position = position;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x001BD714 File Offset: 0x001BB914
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
