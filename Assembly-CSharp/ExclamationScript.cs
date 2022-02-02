using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x06001474 RID: 5236 RVA: 0x000C7660 File Offset: 0x000C5860
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x06001475 RID: 5237 RVA: 0x000C76B8 File Offset: 0x000C58B8
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

	// Token: 0x04001F93 RID: 8083
	public Renderer Graphic;

	// Token: 0x04001F94 RID: 8084
	public float Alpha;

	// Token: 0x04001F95 RID: 8085
	public float Timer;

	// Token: 0x04001F96 RID: 8086
	public Camera MainCamera;
}
