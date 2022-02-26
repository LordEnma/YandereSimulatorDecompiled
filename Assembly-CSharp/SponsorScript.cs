using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043C RID: 1084
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CEA RID: 7402 RVA: 0x00157FD4 File Offset: 0x001561D4
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CEB RID: 7403 RVA: 0x0015804C File Offset: 0x0015624C
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

	// Token: 0x04003421 RID: 13345
	public GameObject[] Set;

	// Token: 0x04003422 RID: 13346
	public UISprite Darkness;

	// Token: 0x04003423 RID: 13347
	public float Timer;

	// Token: 0x04003424 RID: 13348
	public int ID;
}
