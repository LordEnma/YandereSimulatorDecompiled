using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x0600189A RID: 6298 RVA: 0x000F1D70 File Offset: 0x000EFF70
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000F1DC2 File Offset: 0x000EFFC2
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x0600189C RID: 6300 RVA: 0x000F1DEE File Offset: 0x000EFFEE
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x0600189D RID: 6301 RVA: 0x000F1E18 File Offset: 0x000F0018
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0600189E RID: 6302 RVA: 0x000F1E9C File Offset: 0x000F009C
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002567 RID: 9575
	public HomeCameraScript HomeCamera;

	// Token: 0x04002568 RID: 9576
	public UILabel Label;

	// Token: 0x04002569 RID: 9577
	public bool FadeIn;

	// Token: 0x0400256A RID: 9578
	public int ID;
}
