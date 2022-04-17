using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BF RID: 1215
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001FCF RID: 8143 RVA: 0x001C0F84 File Offset: 0x001BF184
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C0FF8 File Offset: 0x001BF1F8
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

	// Token: 0x0400429C RID: 17052
	public float[] Triggers;

	// Token: 0x0400429D RID: 17053
	public string[] Text;

	// Token: 0x0400429E RID: 17054
	public UILabel WarningLabel;

	// Token: 0x0400429F RID: 17055
	public UISprite Darkness;

	// Token: 0x040042A0 RID: 17056
	public UILabel Label;

	// Token: 0x040042A1 RID: 17057
	public bool FadeOut;

	// Token: 0x040042A2 RID: 17058
	public float Timer;

	// Token: 0x040042A3 RID: 17059
	public int ID;
}
