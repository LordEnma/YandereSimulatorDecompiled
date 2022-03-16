using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043D RID: 1085
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CF9 RID: 7417 RVA: 0x00159464 File Offset: 0x00157664
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CFA RID: 7418 RVA: 0x001594DC File Offset: 0x001576DC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer < 3.2f)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			return;
		}
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
		if (this.Darkness.color.a == 1f)
		{
			SceneManager.LoadScene("NewTitleScene");
		}
	}

	// Token: 0x0400346C RID: 13420
	public GameObject[] Set;

	// Token: 0x0400346D RID: 13421
	public UISprite Darkness;

	// Token: 0x0400346E RID: 13422
	public float Timer;

	// Token: 0x0400346F RID: 13423
	public int ID;
}
