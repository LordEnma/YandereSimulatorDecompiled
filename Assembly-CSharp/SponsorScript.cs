using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000440 RID: 1088
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001D03 RID: 7427 RVA: 0x00159FC0 File Offset: 0x001581C0
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001D04 RID: 7428 RVA: 0x0015A038 File Offset: 0x00158238
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

	// Token: 0x04003488 RID: 13448
	public GameObject[] Set;

	// Token: 0x04003489 RID: 13449
	public UISprite Darkness;

	// Token: 0x0400348A RID: 13450
	public float Timer;

	// Token: 0x0400348B RID: 13451
	public int ID;
}
