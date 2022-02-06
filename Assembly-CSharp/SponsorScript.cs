using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043A RID: 1082
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CDA RID: 7386 RVA: 0x00157220 File Offset: 0x00155420
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CDB RID: 7387 RVA: 0x00157298 File Offset: 0x00155498
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

	// Token: 0x0400340B RID: 13323
	public GameObject[] Set;

	// Token: 0x0400340C RID: 13324
	public UISprite Darkness;

	// Token: 0x0400340D RID: 13325
	public float Timer;

	// Token: 0x0400340E RID: 13326
	public int ID;
}
