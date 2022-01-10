using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B4 RID: 1204
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F87 RID: 8071 RVA: 0x001BA4F4 File Offset: 0x001B86F4
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F88 RID: 8072 RVA: 0x001BA568 File Offset: 0x001B8768
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

	// Token: 0x040041C7 RID: 16839
	public float[] Triggers;

	// Token: 0x040041C8 RID: 16840
	public string[] Text;

	// Token: 0x040041C9 RID: 16841
	public UILabel WarningLabel;

	// Token: 0x040041CA RID: 16842
	public UISprite Darkness;

	// Token: 0x040041CB RID: 16843
	public UILabel Label;

	// Token: 0x040041CC RID: 16844
	public bool FadeOut;

	// Token: 0x040041CD RID: 16845
	public float Timer;

	// Token: 0x040041CE RID: 16846
	public int ID;
}
