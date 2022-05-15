using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004E0 RID: 1248
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x060020D4 RID: 8404 RVA: 0x001E5548 File Offset: 0x001E3748
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x060020D5 RID: 8405 RVA: 0x001E55B8 File Offset: 0x001E37B8
	private void FixedUpdate()
	{
		this.TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
		if (this.TargetZoom < 0f)
		{
			this.TargetZoom = 0f;
		}
		if (this.TargetZoom > 3.85f)
		{
			this.TargetZoom = 3.85f;
		}
		this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
		if (!this.Cutscene)
		{
			this.TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
			base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f + this.Zoom);
			if (base.transform.position.x > 47.9f)
			{
				base.transform.position = new Vector3(47.9f, base.transform.position.y, base.transform.position.z);
				return;
			}
		}
		else
		{
			if (this.StopMusic)
			{
				if (this.Yanmont.Dracula.Health > 0f)
				{
					this.TargetZoom = 3.85f;
				}
				AudioSource component = this.Jukebox.GetComponent<AudioSource>();
				component.volume -= Time.deltaTime * ((this.Yanmont.Health > 0f) ? 0.2f : 0.025f);
				if (component.volume <= 0f)
				{
					this.StopMusic = false;
				}
			}
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34.675f, Time.deltaTime * this.Yanmont.walkSpeed), 8f, -5.85f + this.Zoom);
		}
	}

	// Token: 0x0400481E RID: 18462
	public PostProcessingProfile Profile;

	// Token: 0x0400481F RID: 18463
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004820 RID: 18464
	public GameObject Jukebox;

	// Token: 0x04004821 RID: 18465
	public bool Cutscene;

	// Token: 0x04004822 RID: 18466
	public bool StopMusic = true;

	// Token: 0x04004823 RID: 18467
	public float TargetZoom;

	// Token: 0x04004824 RID: 18468
	public float Zoom;
}
