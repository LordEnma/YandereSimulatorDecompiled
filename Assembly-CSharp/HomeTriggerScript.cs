using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018C8 RID: 6344 RVA: 0x000F42F4 File Offset: 0x000F24F4
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018C9 RID: 6345 RVA: 0x000F4346 File Offset: 0x000F2546
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018CA RID: 6346 RVA: 0x000F4372 File Offset: 0x000F2572
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018CB RID: 6347 RVA: 0x000F439C File Offset: 0x000F259C
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x000F4420 File Offset: 0x000F2620
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x040025D6 RID: 9686
	public HomeCameraScript HomeCamera;

	// Token: 0x040025D7 RID: 9687
	public UILabel Label;

	// Token: 0x040025D8 RID: 9688
	public bool FadeIn;

	// Token: 0x040025D9 RID: 9689
	public int ID;
}
