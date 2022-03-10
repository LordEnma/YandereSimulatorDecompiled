using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004EB RID: 1259
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x060020DE RID: 8414 RVA: 0x001E4D80 File Offset: 0x001E2F80
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x060020DF RID: 8415 RVA: 0x001E4DAC File Offset: 0x001E2FAC
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

	// Token: 0x04004871 RID: 18545
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04004872 RID: 18546
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004873 RID: 18547
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004874 RID: 18548
	public Camera MyCamera;

	// Token: 0x04004875 RID: 18549
	public YandereScript Yandere;

	// Token: 0x04004876 RID: 18550
	public GameObject[] Label;

	// Token: 0x04004877 RID: 18551
	public GameObject[] Trees;

	// Token: 0x04004878 RID: 18552
	public Animation Girl;

	// Token: 0x04004879 RID: 18553
	public float Strength;

	// Token: 0x0400487A RID: 18554
	public float Focus = 1f;

	// Token: 0x0400487B RID: 18555
	public float Bloom = 60f;

	// Token: 0x0400487C RID: 18556
	public float Knee = 1f;

	// Token: 0x0400487D RID: 18557
	public float Radius = 7f;

	// Token: 0x0400487E RID: 18558
	public float Threshold;

	// Token: 0x0400487F RID: 18559
	public float Speed;

	// Token: 0x04004880 RID: 18560
	public float Timer;

	// Token: 0x04004881 RID: 18561
	public bool Begin;

	// Token: 0x04004882 RID: 18562
	public int Phase;

	// Token: 0x04004883 RID: 18563
	public int Type;
}
