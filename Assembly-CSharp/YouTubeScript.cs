using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x0600211D RID: 8477 RVA: 0x001EAA38 File Offset: 0x001E8C38
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x0600211E RID: 8478 RVA: 0x001EAA64 File Offset: 0x001E8C64
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

	// Token: 0x0400492D RID: 18733
	public RetroCameraEffect EightiesEffects;

	// Token: 0x0400492E RID: 18734
	public CameraEffectsScript CameraEffects;

	// Token: 0x0400492F RID: 18735
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004930 RID: 18736
	public Camera MyCamera;

	// Token: 0x04004931 RID: 18737
	public YandereScript Yandere;

	// Token: 0x04004932 RID: 18738
	public GameObject[] Label;

	// Token: 0x04004933 RID: 18739
	public GameObject[] Trees;

	// Token: 0x04004934 RID: 18740
	public Animation Girl;

	// Token: 0x04004935 RID: 18741
	public float Strength;

	// Token: 0x04004936 RID: 18742
	public float Focus = 1f;

	// Token: 0x04004937 RID: 18743
	public float Bloom = 60f;

	// Token: 0x04004938 RID: 18744
	public float Knee = 1f;

	// Token: 0x04004939 RID: 18745
	public float Radius = 7f;

	// Token: 0x0400493A RID: 18746
	public float Threshold;

	// Token: 0x0400493B RID: 18747
	public float Speed;

	// Token: 0x0400493C RID: 18748
	public float Timer;

	// Token: 0x0400493D RID: 18749
	public bool Begin;

	// Token: 0x0400493E RID: 18750
	public int Phase;

	// Token: 0x0400493F RID: 18751
	public int Type;
}
