using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B2 RID: 1202
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F7C RID: 8060 RVA: 0x001B9B74 File Offset: 0x001B7D74
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F7D RID: 8061 RVA: 0x001B9BE8 File Offset: 0x001B7DE8
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

	// Token: 0x040041B3 RID: 16819
	public float[] Triggers;

	// Token: 0x040041B4 RID: 16820
	public string[] Text;

	// Token: 0x040041B5 RID: 16821
	public UILabel WarningLabel;

	// Token: 0x040041B6 RID: 16822
	public UISprite Darkness;

	// Token: 0x040041B7 RID: 16823
	public UILabel Label;

	// Token: 0x040041B8 RID: 16824
	public bool FadeOut;

	// Token: 0x040041B9 RID: 16825
	public float Timer;

	// Token: 0x040041BA RID: 16826
	public int ID;
}
