using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000439 RID: 1081
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CD5 RID: 7381 RVA: 0x0015543C File Offset: 0x0015363C
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CD6 RID: 7382 RVA: 0x001554B4 File Offset: 0x001536B4
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

	// Token: 0x040033FC RID: 13308
	public GameObject[] Set;

	// Token: 0x040033FD RID: 13309
	public UISprite Darkness;

	// Token: 0x040033FE RID: 13310
	public float Timer;

	// Token: 0x040033FF RID: 13311
	public int ID;
}
