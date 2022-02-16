using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x060020CF RID: 8399 RVA: 0x001E37C8 File Offset: 0x001E19C8
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x060020D0 RID: 8400 RVA: 0x001E37F4 File Offset: 0x001E19F4
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

	// Token: 0x04004844 RID: 18500
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04004845 RID: 18501
	public CameraEffectsScript CameraEffects;

	// Token: 0x04004846 RID: 18502
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004847 RID: 18503
	public Camera MyCamera;

	// Token: 0x04004848 RID: 18504
	public YandereScript Yandere;

	// Token: 0x04004849 RID: 18505
	public GameObject[] Label;

	// Token: 0x0400484A RID: 18506
	public GameObject[] Trees;

	// Token: 0x0400484B RID: 18507
	public Animation Girl;

	// Token: 0x0400484C RID: 18508
	public float Strength;

	// Token: 0x0400484D RID: 18509
	public float Focus = 1f;

	// Token: 0x0400484E RID: 18510
	public float Bloom = 60f;

	// Token: 0x0400484F RID: 18511
	public float Knee = 1f;

	// Token: 0x04004850 RID: 18512
	public float Radius = 7f;

	// Token: 0x04004851 RID: 18513
	public float Threshold;

	// Token: 0x04004852 RID: 18514
	public float Speed;

	// Token: 0x04004853 RID: 18515
	public float Timer;

	// Token: 0x04004854 RID: 18516
	public bool Begin;

	// Token: 0x04004855 RID: 18517
	public int Phase;

	// Token: 0x04004856 RID: 18518
	public int Type;
}
