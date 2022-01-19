using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x06001897 RID: 6295 RVA: 0x000F17B8 File Offset: 0x000EF9B8
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x06001898 RID: 6296 RVA: 0x000F180A File Offset: 0x000EFA0A
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x06001899 RID: 6297 RVA: 0x000F1836 File Offset: 0x000EFA36
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x000F1860 File Offset: 0x000EFA60
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000F18E4 File Offset: 0x000EFAE4
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x0400255E RID: 9566
	public HomeCameraScript HomeCamera;

	// Token: 0x0400255F RID: 9567
	public UILabel Label;

	// Token: 0x04002560 RID: 9568
	public bool FadeIn;

	// Token: 0x04002561 RID: 9569
	public int ID;
}
