using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B7 RID: 1207
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001FA0 RID: 8096 RVA: 0x001BCBB8 File Offset: 0x001BADB8
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001FA1 RID: 8097 RVA: 0x001BCC2C File Offset: 0x001BAE2C
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

	// Token: 0x040041F8 RID: 16888
	public float[] Triggers;

	// Token: 0x040041F9 RID: 16889
	public string[] Text;

	// Token: 0x040041FA RID: 16890
	public UILabel WarningLabel;

	// Token: 0x040041FB RID: 16891
	public UISprite Darkness;

	// Token: 0x040041FC RID: 16892
	public UILabel Label;

	// Token: 0x040041FD RID: 16893
	public bool FadeOut;

	// Token: 0x040041FE RID: 16894
	public float Timer;

	// Token: 0x040041FF RID: 16895
	public int ID;
}
