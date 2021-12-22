using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000437 RID: 1079
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CCC RID: 7372 RVA: 0x00154CF4 File Offset: 0x00152EF4
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x00154D6C File Offset: 0x00152F6C
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

	// Token: 0x040033EF RID: 13295
	public GameObject[] Set;

	// Token: 0x040033F0 RID: 13296
	public UISprite Darkness;

	// Token: 0x040033F1 RID: 13297
	public float Timer;

	// Token: 0x040033F2 RID: 13298
	public int ID;
}
