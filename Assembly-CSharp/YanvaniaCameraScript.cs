using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004D9 RID: 1241
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x060020A3 RID: 8355 RVA: 0x001E01A8 File Offset: 0x001DE3A8
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x060020A4 RID: 8356 RVA: 0x001E0218 File Offset: 0x001DE418
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

	// Token: 0x0400479A RID: 18330
	public PostProcessingProfile Profile;

	// Token: 0x0400479B RID: 18331
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400479C RID: 18332
	public GameObject Jukebox;

	// Token: 0x0400479D RID: 18333
	public bool Cutscene;

	// Token: 0x0400479E RID: 18334
	public bool StopMusic = true;

	// Token: 0x0400479F RID: 18335
	public float TargetZoom;

	// Token: 0x040047A0 RID: 18336
	public float Zoom;
}
