using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x0600148C RID: 5260 RVA: 0x000C8974 File Offset: 0x000C6B74
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x0600148D RID: 5261 RVA: 0x000C89CC File Offset: 0x000C6BCC
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

	// Token: 0x04001FC8 RID: 8136
	public Renderer Graphic;

	// Token: 0x04001FC9 RID: 8137
	public float Alpha;

	// Token: 0x04001FCA RID: 8138
	public float Timer;

	// Token: 0x04001FCB RID: 8139
	public Camera MainCamera;
}
