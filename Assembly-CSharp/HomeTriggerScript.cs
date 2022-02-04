using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x06001898 RID: 6296 RVA: 0x000F1C84 File Offset: 0x000EFE84
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x06001899 RID: 6297 RVA: 0x000F1CD6 File Offset: 0x000EFED6
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x000F1D02 File Offset: 0x000EFF02
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000F1D2C File Offset: 0x000EFF2C
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0600189C RID: 6300 RVA: 0x000F1DB0 File Offset: 0x000EFFB0
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002564 RID: 9572
	public HomeCameraScript HomeCamera;

	// Token: 0x04002565 RID: 9573
	public UILabel Label;

	// Token: 0x04002566 RID: 9574
	public bool FadeIn;

	// Token: 0x04002567 RID: 9575
	public int ID;
}
