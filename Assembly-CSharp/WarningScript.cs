using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BB RID: 1211
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001FB7 RID: 8119 RVA: 0x001BEB14 File Offset: 0x001BCD14
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x001BEB88 File Offset: 0x001BCD88
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

	// Token: 0x0400425C RID: 16988
	public float[] Triggers;

	// Token: 0x0400425D RID: 16989
	public string[] Text;

	// Token: 0x0400425E RID: 16990
	public UILabel WarningLabel;

	// Token: 0x0400425F RID: 16991
	public UISprite Darkness;

	// Token: 0x04004260 RID: 16992
	public UILabel Label;

	// Token: 0x04004261 RID: 16993
	public bool FadeOut;

	// Token: 0x04004262 RID: 16994
	public float Timer;

	// Token: 0x04004263 RID: 16995
	public int ID;
}
