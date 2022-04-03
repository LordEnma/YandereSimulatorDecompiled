using System;
using UnityEngine;

// Token: 0x02000328 RID: 808
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018B5 RID: 6325 RVA: 0x000F3614 File Offset: 0x000F1814
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018B6 RID: 6326 RVA: 0x000F3666 File Offset: 0x000F1866
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018B7 RID: 6327 RVA: 0x000F3692 File Offset: 0x000F1892
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018B8 RID: 6328 RVA: 0x000F36BC File Offset: 0x000F18BC
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018B9 RID: 6329 RVA: 0x000F3740 File Offset: 0x000F1940
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x040025B4 RID: 9652
	public HomeCameraScript HomeCamera;

	// Token: 0x040025B5 RID: 9653
	public UILabel Label;

	// Token: 0x040025B6 RID: 9654
	public bool FadeIn;

	// Token: 0x040025B7 RID: 9655
	public int ID;
}
