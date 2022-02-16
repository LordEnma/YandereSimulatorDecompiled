using System;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018A1 RID: 6305 RVA: 0x000F1EDC File Offset: 0x000F00DC
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018A2 RID: 6306 RVA: 0x000F1F2E File Offset: 0x000F012E
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x000F1F5A File Offset: 0x000F015A
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F1F84 File Offset: 0x000F0184
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018A5 RID: 6309 RVA: 0x000F2008 File Offset: 0x000F0208
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x0400256D RID: 9581
	public HomeCameraScript HomeCamera;

	// Token: 0x0400256E RID: 9582
	public UILabel Label;

	// Token: 0x0400256F RID: 9583
	public bool FadeIn;

	// Token: 0x04002570 RID: 9584
	public int ID;
}
