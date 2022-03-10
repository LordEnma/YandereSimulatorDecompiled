using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x06001482 RID: 5250 RVA: 0x000C82C8 File Offset: 0x000C64C8
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x000C8320 File Offset: 0x000C6520
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

	// Token: 0x04001FB3 RID: 8115
	public Renderer Graphic;

	// Token: 0x04001FB4 RID: 8116
	public float Alpha;

	// Token: 0x04001FB5 RID: 8117
	public float Timer;

	// Token: 0x04001FB6 RID: 8118
	public Camera MainCamera;
}
