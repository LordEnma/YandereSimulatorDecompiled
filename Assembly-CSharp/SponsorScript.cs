using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000436 RID: 1078
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CC4 RID: 7364 RVA: 0x001543D0 File Offset: 0x001525D0
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CC5 RID: 7365 RVA: 0x00154448 File Offset: 0x00152648
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

	// Token: 0x040033C4 RID: 13252
	public GameObject[] Set;

	// Token: 0x040033C5 RID: 13253
	public UISprite Darkness;

	// Token: 0x040033C6 RID: 13254
	public float Timer;

	// Token: 0x040033C7 RID: 13255
	public int ID;
}
