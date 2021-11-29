using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x0600209E RID: 8350 RVA: 0x001DF1C4 File Offset: 0x001DD3C4
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x0600209F RID: 8351 RVA: 0x001DF1F0 File Offset: 0x001DD3F0
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

	// Token: 0x040047C4 RID: 18372
	public RetroCameraEffect EightiesEffects;

	// Token: 0x040047C5 RID: 18373
	public CameraEffectsScript CameraEffects;

	// Token: 0x040047C6 RID: 18374
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x040047C7 RID: 18375
	public Camera MyCamera;

	// Token: 0x040047C8 RID: 18376
	public YandereScript Yandere;

	// Token: 0x040047C9 RID: 18377
	public GameObject[] Label;

	// Token: 0x040047CA RID: 18378
	public GameObject[] Trees;

	// Token: 0x040047CB RID: 18379
	public Animation Girl;

	// Token: 0x040047CC RID: 18380
	public float Strength;

	// Token: 0x040047CD RID: 18381
	public float Focus = 1f;

	// Token: 0x040047CE RID: 18382
	public float Bloom = 60f;

	// Token: 0x040047CF RID: 18383
	public float Knee = 1f;

	// Token: 0x040047D0 RID: 18384
	public float Radius = 7f;

	// Token: 0x040047D1 RID: 18385
	public float Threshold;

	// Token: 0x040047D2 RID: 18386
	public float Speed;

	// Token: 0x040047D3 RID: 18387
	public float Timer;

	// Token: 0x040047D4 RID: 18388
	public bool Begin;

	// Token: 0x040047D5 RID: 18389
	public int Phase;

	// Token: 0x040047D6 RID: 18390
	public int Type;
}
