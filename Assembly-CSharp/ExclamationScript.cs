using System;
using UnityEngine;

// Token: 0x020002BD RID: 701
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x0600146F RID: 5231 RVA: 0x000C70A8 File Offset: 0x000C52A8
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x06001470 RID: 5232 RVA: 0x000C7100 File Offset: 0x000C5300
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

	// Token: 0x04001F88 RID: 8072
	public Renderer Graphic;

	// Token: 0x04001F89 RID: 8073
	public float Alpha;

	// Token: 0x04001F8A RID: 8074
	public float Timer;

	// Token: 0x04001F8B RID: 8075
	public Camera MainCamera;
}
