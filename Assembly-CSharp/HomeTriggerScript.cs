using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018AF RID: 6319 RVA: 0x000F2FB8 File Offset: 0x000F11B8
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018B0 RID: 6320 RVA: 0x000F300A File Offset: 0x000F120A
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x000F3036 File Offset: 0x000F1236
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018B2 RID: 6322 RVA: 0x000F3060 File Offset: 0x000F1260
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018B3 RID: 6323 RVA: 0x000F30E4 File Offset: 0x000F12E4
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x040025A1 RID: 9633
	public HomeCameraScript HomeCamera;

	// Token: 0x040025A2 RID: 9634
	public UILabel Label;

	// Token: 0x040025A3 RID: 9635
	public bool FadeIn;

	// Token: 0x040025A4 RID: 9636
	public int ID;
}
