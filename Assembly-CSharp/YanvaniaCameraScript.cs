using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004D1 RID: 1233
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x0600206A RID: 8298 RVA: 0x001DAD48 File Offset: 0x001D8F48
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x0600206B RID: 8299 RVA: 0x001DADB8 File Offset: 0x001D8FB8
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

	// Token: 0x040046EA RID: 18154
	public PostProcessingProfile Profile;

	// Token: 0x040046EB RID: 18155
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046EC RID: 18156
	public GameObject Jukebox;

	// Token: 0x040046ED RID: 18157
	public bool Cutscene;

	// Token: 0x040046EE RID: 18158
	public bool StopMusic = true;

	// Token: 0x040046EF RID: 18159
	public float TargetZoom;

	// Token: 0x040046F0 RID: 18160
	public float Zoom;
}
