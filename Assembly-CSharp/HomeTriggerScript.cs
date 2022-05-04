using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018C3 RID: 6339 RVA: 0x000F3E78 File Offset: 0x000F2078
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018C4 RID: 6340 RVA: 0x000F3ECA File Offset: 0x000F20CA
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018C5 RID: 6341 RVA: 0x000F3EF6 File Offset: 0x000F20F6
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018C6 RID: 6342 RVA: 0x000F3F20 File Offset: 0x000F2120
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018C7 RID: 6343 RVA: 0x000F3FA4 File Offset: 0x000F21A4
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x040025C8 RID: 9672
	public HomeCameraScript HomeCamera;

	// Token: 0x040025C9 RID: 9673
	public UILabel Label;

	// Token: 0x040025CA RID: 9674
	public bool FadeIn;

	// Token: 0x040025CB RID: 9675
	public int ID;
}
