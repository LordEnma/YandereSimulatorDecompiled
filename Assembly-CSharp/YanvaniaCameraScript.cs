using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004D3 RID: 1235
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x0600207C RID: 8316 RVA: 0x001DCC88 File Offset: 0x001DAE88
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x0600207D RID: 8317 RVA: 0x001DCCF8 File Offset: 0x001DAEF8
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

	// Token: 0x0400470E RID: 18190
	public PostProcessingProfile Profile;

	// Token: 0x0400470F RID: 18191
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004710 RID: 18192
	public GameObject Jukebox;

	// Token: 0x04004711 RID: 18193
	public bool Cutscene;

	// Token: 0x04004712 RID: 18194
	public bool StopMusic = true;

	// Token: 0x04004713 RID: 18195
	public float TargetZoom;

	// Token: 0x04004714 RID: 18196
	public float Zoom;
}
