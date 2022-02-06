﻿using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004D2 RID: 1234
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x06002075 RID: 8309 RVA: 0x001DC7D4 File Offset: 0x001DA9D4
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x06002076 RID: 8310 RVA: 0x001DC844 File Offset: 0x001DAA44
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

	// Token: 0x04004705 RID: 18181
	public PostProcessingProfile Profile;

	// Token: 0x04004706 RID: 18182
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004707 RID: 18183
	public GameObject Jukebox;

	// Token: 0x04004708 RID: 18184
	public bool Cutscene;

	// Token: 0x04004709 RID: 18185
	public bool StopMusic = true;

	// Token: 0x0400470A RID: 18186
	public float TargetZoom;

	// Token: 0x0400470B RID: 18187
	public float Zoom;
}
