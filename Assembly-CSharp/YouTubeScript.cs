using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x0600210C RID: 8460 RVA: 0x001E8A54 File Offset: 0x001E6C54
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x0600210D RID: 8461 RVA: 0x001E8A80 File Offset: 0x001E6C80
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

	// Token: 0x04004905 RID: 18693
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04004906 RID: 18694
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004907 RID: 18695
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004908 RID: 18696
	public Camera MyCamera;

	// Token: 0x04004909 RID: 18697
	public YandereScript Yandere;

	// Token: 0x0400490A RID: 18698
	public GameObject[] Label;

	// Token: 0x0400490B RID: 18699
	public GameObject[] Trees;

	// Token: 0x0400490C RID: 18700
	public Animation Girl;

	// Token: 0x0400490D RID: 18701
	public float Strength;

	// Token: 0x0400490E RID: 18702
	public float Focus = 1f;

	// Token: 0x0400490F RID: 18703
	public float Bloom = 60f;

	// Token: 0x04004910 RID: 18704
	public float Knee = 1f;

	// Token: 0x04004911 RID: 18705
	public float Radius = 7f;

	// Token: 0x04004912 RID: 18706
	public float Threshold;

	// Token: 0x04004913 RID: 18707
	public float Speed;

	// Token: 0x04004914 RID: 18708
	public float Timer;

	// Token: 0x04004915 RID: 18709
	public bool Begin;

	// Token: 0x04004916 RID: 18710
	public int Phase;

	// Token: 0x04004917 RID: 18711
	public int Type;
}
