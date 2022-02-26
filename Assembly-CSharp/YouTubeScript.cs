using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004EA RID: 1258
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x001E43A8 File Offset: 0x001E25A8
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x001E43D4 File Offset: 0x001E25D4
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

	// Token: 0x04004854 RID: 18516
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04004855 RID: 18517
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004856 RID: 18518
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004857 RID: 18519
	public Camera MyCamera;

	// Token: 0x04004858 RID: 18520
	public YandereScript Yandere;

	// Token: 0x04004859 RID: 18521
	public GameObject[] Label;

	// Token: 0x0400485A RID: 18522
	public GameObject[] Trees;

	// Token: 0x0400485B RID: 18523
	public Animation Girl;

	// Token: 0x0400485C RID: 18524
	public float Strength;

	// Token: 0x0400485D RID: 18525
	public float Focus = 1f;

	// Token: 0x0400485E RID: 18526
	public float Bloom = 60f;

	// Token: 0x0400485F RID: 18527
	public float Knee = 1f;

	// Token: 0x04004860 RID: 18528
	public float Radius = 7f;

	// Token: 0x04004861 RID: 18529
	public float Threshold;

	// Token: 0x04004862 RID: 18530
	public float Speed;

	// Token: 0x04004863 RID: 18531
	public float Timer;

	// Token: 0x04004864 RID: 18532
	public bool Begin;

	// Token: 0x04004865 RID: 18533
	public int Phase;

	// Token: 0x04004866 RID: 18534
	public int Type;
}
