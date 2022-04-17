using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x06002113 RID: 8467 RVA: 0x001E94B0 File Offset: 0x001E76B0
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x001E94DC File Offset: 0x001E76DC
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

	// Token: 0x04004917 RID: 18711
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04004918 RID: 18712
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004919 RID: 18713
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x0400491A RID: 18714
	public Camera MyCamera;

	// Token: 0x0400491B RID: 18715
	public YandereScript Yandere;

	// Token: 0x0400491C RID: 18716
	public GameObject[] Label;

	// Token: 0x0400491D RID: 18717
	public GameObject[] Trees;

	// Token: 0x0400491E RID: 18718
	public Animation Girl;

	// Token: 0x0400491F RID: 18719
	public float Strength;

	// Token: 0x04004920 RID: 18720
	public float Focus = 1f;

	// Token: 0x04004921 RID: 18721
	public float Bloom = 60f;

	// Token: 0x04004922 RID: 18722
	public float Knee = 1f;

	// Token: 0x04004923 RID: 18723
	public float Radius = 7f;

	// Token: 0x04004924 RID: 18724
	public float Threshold;

	// Token: 0x04004925 RID: 18725
	public float Speed;

	// Token: 0x04004926 RID: 18726
	public float Timer;

	// Token: 0x04004927 RID: 18727
	public bool Begin;

	// Token: 0x04004928 RID: 18728
	public int Phase;

	// Token: 0x04004929 RID: 18729
	public int Type;
}
