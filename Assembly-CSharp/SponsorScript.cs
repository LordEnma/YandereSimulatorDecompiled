using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000441 RID: 1089
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001D0E RID: 7438 RVA: 0x0015A6F0 File Offset: 0x001588F0
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001D0F RID: 7439 RVA: 0x0015A768 File Offset: 0x00158968
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

	// Token: 0x04003496 RID: 13462
	public GameObject[] Set;

	// Token: 0x04003497 RID: 13463
	public UISprite Darkness;

	// Token: 0x04003498 RID: 13464
	public float Timer;

	// Token: 0x04003499 RID: 13465
	public int ID;
}
