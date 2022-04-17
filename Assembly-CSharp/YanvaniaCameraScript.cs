using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004DE RID: 1246
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x060020C0 RID: 8384 RVA: 0x001E2970 File Offset: 0x001E0B70
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x060020C1 RID: 8385 RVA: 0x001E29E0 File Offset: 0x001E0BE0
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

	// Token: 0x040047E1 RID: 18401
	public PostProcessingProfile Profile;

	// Token: 0x040047E2 RID: 18402
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047E3 RID: 18403
	public GameObject Jukebox;

	// Token: 0x040047E4 RID: 18404
	public bool Cutscene;

	// Token: 0x040047E5 RID: 18405
	public bool StopMusic = true;

	// Token: 0x040047E6 RID: 18406
	public float TargetZoom;

	// Token: 0x040047E7 RID: 18407
	public float Zoom;
}
