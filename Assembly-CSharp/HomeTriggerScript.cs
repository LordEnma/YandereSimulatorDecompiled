using System;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018BF RID: 6335 RVA: 0x000F39A8 File Offset: 0x000F1BA8
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018C0 RID: 6336 RVA: 0x000F39FA File Offset: 0x000F1BFA
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018C1 RID: 6337 RVA: 0x000F3A26 File Offset: 0x000F1C26
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x000F3A50 File Offset: 0x000F1C50
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018C3 RID: 6339 RVA: 0x000F3AD4 File Offset: 0x000F1CD4
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x040025BF RID: 9663
	public HomeCameraScript HomeCamera;

	// Token: 0x040025C0 RID: 9664
	public UILabel Label;

	// Token: 0x040025C1 RID: 9665
	public bool FadeIn;

	// Token: 0x040025C2 RID: 9666
	public int ID;
}
