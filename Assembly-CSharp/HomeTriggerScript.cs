using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x0600188A RID: 6282 RVA: 0x000F08E4 File Offset: 0x000EEAE4
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x0600188B RID: 6283 RVA: 0x000F0936 File Offset: 0x000EEB36
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x0600188C RID: 6284 RVA: 0x000F0962 File Offset: 0x000EEB62
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x0600188D RID: 6285 RVA: 0x000F098C File Offset: 0x000EEB8C
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0600188E RID: 6286 RVA: 0x000F0A10 File Offset: 0x000EEC10
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002533 RID: 9523
	public HomeCameraScript HomeCamera;

	// Token: 0x04002534 RID: 9524
	public UILabel Label;

	// Token: 0x04002535 RID: 9525
	public bool FadeIn;

	// Token: 0x04002536 RID: 9526
	public int ID;
}
