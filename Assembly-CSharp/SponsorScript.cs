using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000437 RID: 1079
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CCE RID: 7374 RVA: 0x00155138 File Offset: 0x00153338
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CCF RID: 7375 RVA: 0x001551B0 File Offset: 0x001533B0
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

	// Token: 0x040033F6 RID: 13302
	public GameObject[] Set;

	// Token: 0x040033F7 RID: 13303
	public UISprite Darkness;

	// Token: 0x040033F8 RID: 13304
	public float Timer;

	// Token: 0x040033F9 RID: 13305
	public int ID;
}
