using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x06001898 RID: 6296 RVA: 0x000F1BCC File Offset: 0x000EFDCC
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x06001899 RID: 6297 RVA: 0x000F1C1E File Offset: 0x000EFE1E
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x000F1C4A File Offset: 0x000EFE4A
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000F1C74 File Offset: 0x000EFE74
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0600189C RID: 6300 RVA: 0x000F1CF8 File Offset: 0x000EFEF8
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002563 RID: 9571
	public HomeCameraScript HomeCamera;

	// Token: 0x04002564 RID: 9572
	public UILabel Label;

	// Token: 0x04002565 RID: 9573
	public bool FadeIn;

	// Token: 0x04002566 RID: 9574
	public int ID;
}
