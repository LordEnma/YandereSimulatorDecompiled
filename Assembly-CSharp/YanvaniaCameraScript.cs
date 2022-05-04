using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004DF RID: 1247
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x060020CA RID: 8394 RVA: 0x001E3EF8 File Offset: 0x001E20F8
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x001E3F68 File Offset: 0x001E2168
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

	// Token: 0x040047F7 RID: 18423
	public PostProcessingProfile Profile;

	// Token: 0x040047F8 RID: 18424
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047F9 RID: 18425
	public GameObject Jukebox;

	// Token: 0x040047FA RID: 18426
	public bool Cutscene;

	// Token: 0x040047FB RID: 18427
	public bool StopMusic = true;

	// Token: 0x040047FC RID: 18428
	public float TargetZoom;

	// Token: 0x040047FD RID: 18429
	public float Zoom;
}
