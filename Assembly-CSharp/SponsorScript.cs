using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200043C RID: 1084
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001CEC RID: 7404 RVA: 0x00158558 File Offset: 0x00156758
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001CED RID: 7405 RVA: 0x001585D0 File Offset: 0x001567D0
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

	// Token: 0x04003437 RID: 13367
	public GameObject[] Set;

	// Token: 0x04003438 RID: 13368
	public UISprite Darkness;

	// Token: 0x04003439 RID: 13369
	public float Timer;

	// Token: 0x0400343A RID: 13370
	public int ID;
}
