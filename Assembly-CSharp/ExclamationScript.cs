using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x06001485 RID: 5253 RVA: 0x000C8738 File Offset: 0x000C6938
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x06001486 RID: 5254 RVA: 0x000C8790 File Offset: 0x000C6990
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

	// Token: 0x04001FC3 RID: 8131
	public Renderer Graphic;

	// Token: 0x04001FC4 RID: 8132
	public float Alpha;

	// Token: 0x04001FC5 RID: 8133
	public float Timer;

	// Token: 0x04001FC6 RID: 8134
	public Camera MainCamera;
}
