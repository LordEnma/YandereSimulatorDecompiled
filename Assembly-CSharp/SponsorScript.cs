using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000443 RID: 1091
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001D1B RID: 7451 RVA: 0x0015BBAC File Offset: 0x00159DAC
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001D1C RID: 7452 RVA: 0x0015BC24 File Offset: 0x00159E24
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

	// Token: 0x040034BA RID: 13498
	public GameObject[] Set;

	// Token: 0x040034BB RID: 13499
	public UISprite Darkness;

	// Token: 0x040034BC RID: 13500
	public float Timer;

	// Token: 0x040034BD RID: 13501
	public int ID;
}
