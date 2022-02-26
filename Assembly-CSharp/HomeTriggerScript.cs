using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018AA RID: 6314 RVA: 0x000F27C0 File Offset: 0x000F09C0
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018AB RID: 6315 RVA: 0x000F2812 File Offset: 0x000F0A12
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018AC RID: 6316 RVA: 0x000F283E File Offset: 0x000F0A3E
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018AD RID: 6317 RVA: 0x000F2868 File Offset: 0x000F0A68
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018AE RID: 6318 RVA: 0x000F28EC File Offset: 0x000F0AEC
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x0400257C RID: 9596
	public HomeCameraScript HomeCamera;

	// Token: 0x0400257D RID: 9597
	public UILabel Label;

	// Token: 0x0400257E RID: 9598
	public bool FadeIn;

	// Token: 0x0400257F RID: 9599
	public int ID;
}
