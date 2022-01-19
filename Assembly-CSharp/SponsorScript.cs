using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043A RID: 1082
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CD7 RID: 7383 RVA: 0x00156B50 File Offset: 0x00154D50
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CD8 RID: 7384 RVA: 0x00156BC8 File Offset: 0x00154DC8
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

	// Token: 0x04003401 RID: 13313
	public GameObject[] Set;

	// Token: 0x04003402 RID: 13314
	public UISprite Darkness;

	// Token: 0x04003403 RID: 13315
	public float Timer;

	// Token: 0x04003404 RID: 13316
	public int ID;
}
