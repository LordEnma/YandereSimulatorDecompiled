using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x060020C5 RID: 8389 RVA: 0x001E3110 File Offset: 0x001E1310
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x060020C6 RID: 8390 RVA: 0x001E313C File Offset: 0x001E133C
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

	// Token: 0x04004838 RID: 18488
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04004839 RID: 18489
	public CameraEffectsScript CameraEffects;

	// Token: 0x0400483A RID: 18490
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x0400483B RID: 18491
	public Camera MyCamera;

	// Token: 0x0400483C RID: 18492
	public YandereScript Yandere;

	// Token: 0x0400483D RID: 18493
	public GameObject[] Label;

	// Token: 0x0400483E RID: 18494
	public GameObject[] Trees;

	// Token: 0x0400483F RID: 18495
	public Animation Girl;

	// Token: 0x04004840 RID: 18496
	public float Strength;

	// Token: 0x04004841 RID: 18497
	public float Focus = 1f;

	// Token: 0x04004842 RID: 18498
	public float Bloom = 60f;

	// Token: 0x04004843 RID: 18499
	public float Knee = 1f;

	// Token: 0x04004844 RID: 18500
	public float Radius = 7f;

	// Token: 0x04004845 RID: 18501
	public float Threshold;

	// Token: 0x04004846 RID: 18502
	public float Speed;

	// Token: 0x04004847 RID: 18503
	public float Timer;

	// Token: 0x04004848 RID: 18504
	public bool Begin;

	// Token: 0x04004849 RID: 18505
	public int Phase;

	// Token: 0x0400484A RID: 18506
	public int Type;
}
