using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x060020F6 RID: 8438 RVA: 0x001E6CE8 File Offset: 0x001E4EE8
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E6D14 File Offset: 0x001E4F14
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

	// Token: 0x040048D0 RID: 18640
	public RetroCameraEffect EightiesEffects;

	// Token: 0x040048D1 RID: 18641
	public CameraEffectsScript CameraEffects;

	// Token: 0x040048D2 RID: 18642
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x040048D3 RID: 18643
	public Camera MyCamera;

	// Token: 0x040048D4 RID: 18644
	public YandereScript Yandere;

	// Token: 0x040048D5 RID: 18645
	public GameObject[] Label;

	// Token: 0x040048D6 RID: 18646
	public GameObject[] Trees;

	// Token: 0x040048D7 RID: 18647
	public Animation Girl;

	// Token: 0x040048D8 RID: 18648
	public float Strength;

	// Token: 0x040048D9 RID: 18649
	public float Focus = 1f;

	// Token: 0x040048DA RID: 18650
	public float Bloom = 60f;

	// Token: 0x040048DB RID: 18651
	public float Knee = 1f;

	// Token: 0x040048DC RID: 18652
	public float Radius = 7f;

	// Token: 0x040048DD RID: 18653
	public float Threshold;

	// Token: 0x040048DE RID: 18654
	public float Speed;

	// Token: 0x040048DF RID: 18655
	public float Timer;

	// Token: 0x040048E0 RID: 18656
	public bool Begin;

	// Token: 0x040048E1 RID: 18657
	public int Phase;

	// Token: 0x040048E2 RID: 18658
	public int Type;
}
