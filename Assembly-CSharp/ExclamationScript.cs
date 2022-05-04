using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x06001490 RID: 5264 RVA: 0x000C8FB4 File Offset: 0x000C71B4
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x06001491 RID: 5265 RVA: 0x000C900C File Offset: 0x000C720C
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

	// Token: 0x04001FD3 RID: 8147
	public Renderer Graphic;

	// Token: 0x04001FD4 RID: 8148
	public float Alpha;

	// Token: 0x04001FD5 RID: 8149
	public float Timer;

	// Token: 0x04001FD6 RID: 8150
	public Camera MainCamera;
}
