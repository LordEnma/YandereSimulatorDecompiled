﻿using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x06001473 RID: 5235 RVA: 0x000C745C File Offset: 0x000C565C
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x06001474 RID: 5236 RVA: 0x000C74B4 File Offset: 0x000C56B4
	private void Update()
	{
		this.Timer -= Time.deltaTime;
		if (this.Timer > 0f)
		{
			base.transform.LookAt(this.MainCamera.transform);
			if (this.Timer > 1.5f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.Alpha = Mathf.Lerp(this.Alpha, 0.5f, Time.deltaTime * 10f);
				this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
				return;
			}
			if (base.transform.localScale.x > 0.1f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else
			{
				base.transform.localScale = Vector3.zero;
			}
			this.Alpha = Mathf.Lerp(this.Alpha, 0f, Time.deltaTime * 10f);
			this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
		}
	}

	// Token: 0x04001F8F RID: 8079
	public Renderer Graphic;

	// Token: 0x04001F90 RID: 8080
	public float Alpha;

	// Token: 0x04001F91 RID: 8081
	public float Timer;

	// Token: 0x04001F92 RID: 8082
	public Camera MainCamera;
}
