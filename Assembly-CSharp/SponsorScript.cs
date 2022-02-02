using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043A RID: 1082
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CD8 RID: 7384 RVA: 0x00156F84 File Offset: 0x00155184
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CD9 RID: 7385 RVA: 0x00156FFC File Offset: 0x001551FC
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

	// Token: 0x04003407 RID: 13319
	public GameObject[] Set;

	// Token: 0x04003408 RID: 13320
	public UISprite Darkness;

	// Token: 0x04003409 RID: 13321
	public float Timer;

	// Token: 0x0400340A RID: 13322
	public int ID;
}
