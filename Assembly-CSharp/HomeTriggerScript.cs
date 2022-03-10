using System;
using UnityEngine;

// Token: 0x02000327 RID: 807
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x060018AA RID: 6314 RVA: 0x000F2AF8 File Offset: 0x000F0CF8
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x060018AB RID: 6315 RVA: 0x000F2B4A File Offset: 0x000F0D4A
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x060018AC RID: 6316 RVA: 0x000F2B76 File Offset: 0x000F0D76
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x060018AD RID: 6317 RVA: 0x000F2BA0 File Offset: 0x000F0DA0
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x060018AE RID: 6318 RVA: 0x000F2C24 File Offset: 0x000F0E24
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002590 RID: 9616
	public HomeCameraScript HomeCamera;

	// Token: 0x04002591 RID: 9617
	public UILabel Label;

	// Token: 0x04002592 RID: 9618
	public bool FadeIn;

	// Token: 0x04002593 RID: 9619
	public int ID;
}
