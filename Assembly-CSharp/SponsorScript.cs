using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043B RID: 1083
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CE1 RID: 7393 RVA: 0x00157528 File Offset: 0x00155728
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CE2 RID: 7394 RVA: 0x001575A0 File Offset: 0x001557A0
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

	// Token: 0x04003411 RID: 13329
	public GameObject[] Set;

	// Token: 0x04003412 RID: 13330
	public UISprite Darkness;

	// Token: 0x04003413 RID: 13331
	public float Timer;

	// Token: 0x04003414 RID: 13332
	public int ID;
}
