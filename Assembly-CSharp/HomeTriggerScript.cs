using System;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018C8 RID: 6344 RVA: 0x000F4178 File Offset: 0x000F2378
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018C9 RID: 6345 RVA: 0x000F41CA File Offset: 0x000F23CA
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018CA RID: 6346 RVA: 0x000F41F6 File Offset: 0x000F23F6
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018CB RID: 6347 RVA: 0x000F4220 File Offset: 0x000F2420
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x000F42A4 File Offset: 0x000F24A4
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x040025D3 RID: 9683
	public HomeCameraScript HomeCamera;

	// Token: 0x040025D4 RID: 9684
	public UILabel Label;

	// Token: 0x040025D5 RID: 9685
	public bool FadeIn;

	// Token: 0x040025D6 RID: 9686
	public int ID;
}
