using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x06001891 RID: 6289 RVA: 0x000F10D4 File Offset: 0x000EF2D4
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x06001892 RID: 6290 RVA: 0x000F1126 File Offset: 0x000EF326
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x06001893 RID: 6291 RVA: 0x000F1152 File Offset: 0x000EF352
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x06001894 RID: 6292 RVA: 0x000F117C File Offset: 0x000EF37C
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x06001895 RID: 6293 RVA: 0x000F1200 File Offset: 0x000EF400
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002553 RID: 9555
	public HomeCameraScript HomeCamera;

	// Token: 0x04002554 RID: 9556
	public UILabel Label;

	// Token: 0x04002555 RID: 9557
	public bool FadeIn;

	// Token: 0x04002556 RID: 9558
	public int ID;
}
