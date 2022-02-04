using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B5 RID: 1205
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F8D RID: 8077 RVA: 0x001BB9F8 File Offset: 0x001B9BF8
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F8E RID: 8078 RVA: 0x001BBA6C File Offset: 0x001B9C6C
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

	// Token: 0x040041DC RID: 16860
	public float[] Triggers;

	// Token: 0x040041DD RID: 16861
	public string[] Text;

	// Token: 0x040041DE RID: 16862
	public UILabel WarningLabel;

	// Token: 0x040041DF RID: 16863
	public UISprite Darkness;

	// Token: 0x040041E0 RID: 16864
	public UILabel Label;

	// Token: 0x040041E1 RID: 16865
	public bool FadeOut;

	// Token: 0x040041E2 RID: 16866
	public float Timer;

	// Token: 0x040041E3 RID: 16867
	public int ID;
}
