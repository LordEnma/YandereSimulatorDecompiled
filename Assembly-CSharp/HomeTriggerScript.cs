using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class HomeTriggerScript : MonoBehaviour
{
	// Token: 0x06001893 RID: 6291 RVA: 0x000F1388 File Offset: 0x000EF588
	private void Start()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
	}

	// Token: 0x06001894 RID: 6292 RVA: 0x000F13DA File Offset: 0x000EF5DA
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = this.ID;
			this.FadeIn = true;
		}
	}

	// Token: 0x06001895 RID: 6293 RVA: 0x000F1406 File Offset: 0x000EF606
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			this.HomeCamera.ID = 0;
			this.FadeIn = false;
		}
	}

	// Token: 0x06001896 RID: 6294 RVA: 0x000F1430 File Offset: 0x000EF630
	private void Update()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0f, Time.deltaTime * 10f));
	}

	// Token: 0x06001897 RID: 6295 RVA: 0x000F14B4 File Offset: 0x000EF6B4
	public void Disable()
	{
		this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0f);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002557 RID: 9559
	public HomeCameraScript HomeCamera;

	// Token: 0x04002558 RID: 9560
	public UILabel Label;

	// Token: 0x04002559 RID: 9561
	public bool FadeIn;

	// Token: 0x0400255A RID: 9562
	public int ID;
}
