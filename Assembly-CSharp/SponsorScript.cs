using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000442 RID: 1090
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001D15 RID: 7445 RVA: 0x0015AF2C File Offset: 0x0015912C
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001D16 RID: 7446 RVA: 0x0015AFA4 File Offset: 0x001591A4
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

	// Token: 0x040034A5 RID: 13477
	public GameObject[] Set;

	// Token: 0x040034A6 RID: 13478
	public UISprite Darkness;

	// Token: 0x040034A7 RID: 13479
	public float Timer;

	// Token: 0x040034A8 RID: 13480
	public int ID;
}
