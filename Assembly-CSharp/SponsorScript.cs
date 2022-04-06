using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000441 RID: 1089
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001D0A RID: 7434 RVA: 0x0015A2E0 File Offset: 0x001584E0
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001D0B RID: 7435 RVA: 0x0015A358 File Offset: 0x00158558
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

	// Token: 0x0400348B RID: 13451
	public GameObject[] Set;

	// Token: 0x0400348C RID: 13452
	public UISprite Darkness;

	// Token: 0x0400348D RID: 13453
	public float Timer;

	// Token: 0x0400348E RID: 13454
	public int ID;
}
