using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x060020BD RID: 8381 RVA: 0x001E1888 File Offset: 0x001DFA88
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x060020BE RID: 8382 RVA: 0x001E18B4 File Offset: 0x001DFAB4
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

	// Token: 0x04004820 RID: 18464
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04004821 RID: 18465
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004822 RID: 18466
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004823 RID: 18467
	public Camera MyCamera;

	// Token: 0x04004824 RID: 18468
	public YandereScript Yandere;

	// Token: 0x04004825 RID: 18469
	public GameObject[] Label;

	// Token: 0x04004826 RID: 18470
	public GameObject[] Trees;

	// Token: 0x04004827 RID: 18471
	public Animation Girl;

	// Token: 0x04004828 RID: 18472
	public float Strength;

	// Token: 0x04004829 RID: 18473
	public float Focus = 1f;

	// Token: 0x0400482A RID: 18474
	public float Bloom = 60f;

	// Token: 0x0400482B RID: 18475
	public float Knee = 1f;

	// Token: 0x0400482C RID: 18476
	public float Radius = 7f;

	// Token: 0x0400482D RID: 18477
	public float Threshold;

	// Token: 0x0400482E RID: 18478
	public float Speed;

	// Token: 0x0400482F RID: 18479
	public float Timer;

	// Token: 0x04004830 RID: 18480
	public bool Begin;

	// Token: 0x04004831 RID: 18481
	public int Phase;

	// Token: 0x04004832 RID: 18482
	public int Type;
}
