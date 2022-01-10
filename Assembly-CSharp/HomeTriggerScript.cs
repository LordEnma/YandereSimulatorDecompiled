using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x06001897 RID: 6295 RVA: 0x000F16C0 File Offset: 0x000EF8C0
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x06001898 RID: 6296 RVA: 0x000F1712 File Offset: 0x000EF912
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x06001899 RID: 6297 RVA: 0x000F173E File Offset: 0x000EF93E
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x000F1768 File Offset: 0x000EF968
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000F17EC File Offset: 0x000EF9EC
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x0400255B RID: 9563
	public HomeCameraScript HomeCamera;

	// Token: 0x0400255C RID: 9564
	public UILabel Label;

	// Token: 0x0400255D RID: 9565
	public bool FadeIn;

	// Token: 0x0400255E RID: 9566
	public int ID;
}
