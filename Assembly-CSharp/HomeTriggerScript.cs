using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018BB RID: 6331 RVA: 0x000F3714 File Offset: 0x000F1914
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018BC RID: 6332 RVA: 0x000F3766 File Offset: 0x000F1966
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x000F3792 File Offset: 0x000F1992
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x000F37BC File Offset: 0x000F19BC
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018BF RID: 6335 RVA: 0x000F3840 File Offset: 0x000F1A40
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x040025B7 RID: 9655
	public HomeCameraScript HomeCamera;

	// Token: 0x040025B8 RID: 9656
	public UILabel Label;

	// Token: 0x040025B9 RID: 9657
	public bool FadeIn;

	// Token: 0x040025BA RID: 9658
	public int ID;
}
