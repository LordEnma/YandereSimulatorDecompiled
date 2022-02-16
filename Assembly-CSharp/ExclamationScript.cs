using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x06001479 RID: 5241 RVA: 0x000C7898 File Offset: 0x000C5A98
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x0600147A RID: 5242 RVA: 0x000C78F0 File Offset: 0x000C5AF0
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

	// Token: 0x04001F9B RID: 8091
	public Renderer Graphic;

	// Token: 0x04001F9C RID: 8092
	public float Alpha;

	// Token: 0x04001F9D RID: 8093
	public float Timer;

	// Token: 0x04001F9E RID: 8094
	public Camera MainCamera;
}
