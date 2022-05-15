using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C1 RID: 1217
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001FE2 RID: 8162 RVA: 0x001C35D4 File Offset: 0x001C17D4
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001FE3 RID: 8163 RVA: 0x001C3648 File Offset: 0x001C1848
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (!this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Darkness.color.a == 0f)
			{
				if (this.Timer == 0f)
				{
					this.WarningLabel.gameObject.SetActive(true);
					component.Play();
				}
				this.Timer += Time.deltaTime;
				if (this.ID < this.Triggers.Length && this.Timer > this.Triggers[this.ID])
				{
					this.Label.text = this.Text[this.ID];
					this.ID++;
				}
			}
		}
		else
		{
			component.volume = Mathf.MoveTowards(component.volume, 0f, Time.deltaTime);
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				SceneManager.LoadScene("SponsorScene");
			}
		}
		if (Input.anyKey)
		{
			this.FadeOut = true;
		}
	}

	// Token: 0x040042D0 RID: 17104
	public float[] Triggers;

	// Token: 0x040042D1 RID: 17105
	public string[] Text;

	// Token: 0x040042D2 RID: 17106
	public UILabel WarningLabel;

	// Token: 0x040042D3 RID: 17107
	public UISprite Darkness;

	// Token: 0x040042D4 RID: 17108
	public UILabel Label;

	// Token: 0x040042D5 RID: 17109
	public bool FadeOut;

	// Token: 0x040042D6 RID: 17110
	public float Timer;

	// Token: 0x040042D7 RID: 17111
	public int ID;
}
