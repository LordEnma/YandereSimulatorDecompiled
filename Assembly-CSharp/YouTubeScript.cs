using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004E5 RID: 1253
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x060020B2 RID: 8370 RVA: 0x001E0EE8 File Offset: 0x001DF0E8
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x060020B3 RID: 8371 RVA: 0x001E0F14 File Offset: 0x001DF114
	private void Update()
	{
		if (this.Type == 6)
		{
			this.MyCamera.orthographicSize -= Time.deltaTime * 0.033333335f;
		}
		if (Input.GetKeyDown("z"))
		{
			this.Phase++;
			if (this.Type == 5)
			{
				this.Label[this.Phase].SetActive(true);
			}
		}
		if (this.Phase > 0)
		{
			if (this.Type == 1)
			{
				base.transform.position += new Vector3(0f, 0f, Time.deltaTime * -0.1f);
			}
			else if (this.Type == 2)
			{
				base.transform.Translate(Vector3.forward * Time.deltaTime * -1f * this.Speed);
			}
			else if (this.Type == 3)
			{
				base.transform.Translate(Vector3.forward * Time.deltaTime * -1f);
				this.Begin = true;
			}
			else if (this.Type == 4)
			{
				this.Begin = true;
			}
		}
		if (this.Begin)
		{
			if (this.Type != 4)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					if (this.Phase == 1)
					{
						this.VaporwaveVisuals.ApplyNormalView();
						RenderSettings.skybox = this.Yandere.VaporwaveSkybox;
						this.Phase++;
						this.Bloom = 5f;
						this.Threshold = 0f;
						this.Knee = 1f;
						this.Radius = 7f;
						this.CameraEffects.UpdateBloom(this.Bloom);
						this.CameraEffects.UpdateThreshold(this.Threshold);
						this.CameraEffects.UpdateBloomKnee(this.Knee);
						this.CameraEffects.UpdateBloomRadius(this.Radius);
						for (int i = 1; i < this.Trees.Length; i++)
						{
							Debug.Log("Deactivating trees...or trying to.");
							this.Trees[i].SetActive(false);
						}
						this.EightiesEffects.enabled = true;
						return;
					}
					this.Bloom = Mathf.Lerp(this.Bloom, 1f, Time.deltaTime);
					this.Threshold = Mathf.Lerp(this.Bloom, 1.1f, Time.deltaTime);
					this.Knee = Mathf.Lerp(this.Bloom, 0.5f, Time.deltaTime);
					this.Radius = Mathf.Lerp(this.Bloom, 4f, Time.deltaTime);
					this.CameraEffects.UpdateBloom(this.Bloom);
					this.CameraEffects.UpdateThreshold(this.Threshold);
					this.CameraEffects.UpdateBloomKnee(this.Knee);
					this.CameraEffects.UpdateBloomRadius(this.Radius);
					return;
				}
			}
			else
			{
				this.Speed += Time.deltaTime;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.3f, 0f, 0.4f), Time.deltaTime * this.Speed);
			}
		}
	}

	// Token: 0x0400480C RID: 18444
	public RetroCameraEffect EightiesEffects;

	// Token: 0x0400480D RID: 18445
	public CameraEffectsScript CameraEffects;

	// Token: 0x0400480E RID: 18446
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x0400480F RID: 18447
	public Camera MyCamera;

	// Token: 0x04004810 RID: 18448
	public YandereScript Yandere;

	// Token: 0x04004811 RID: 18449
	public GameObject[] Label;

	// Token: 0x04004812 RID: 18450
	public GameObject[] Trees;

	// Token: 0x04004813 RID: 18451
	public Animation Girl;

	// Token: 0x04004814 RID: 18452
	public float Strength;

	// Token: 0x04004815 RID: 18453
	public float Focus = 1f;

	// Token: 0x04004816 RID: 18454
	public float Bloom = 60f;

	// Token: 0x04004817 RID: 18455
	public float Knee = 1f;

	// Token: 0x04004818 RID: 18456
	public float Radius = 7f;

	// Token: 0x04004819 RID: 18457
	public float Threshold;

	// Token: 0x0400481A RID: 18458
	public float Speed;

	// Token: 0x0400481B RID: 18459
	public float Timer;

	// Token: 0x0400481C RID: 18460
	public bool Begin;

	// Token: 0x0400481D RID: 18461
	public int Phase;

	// Token: 0x0400481E RID: 18462
	public int Type;
}
