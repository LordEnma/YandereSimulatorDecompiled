using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B5 RID: 1205
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F90 RID: 8080 RVA: 0x001BBC18 File Offset: 0x001B9E18
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F91 RID: 8081 RVA: 0x001BBC8C File Offset: 0x001B9E8C
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

	// Token: 0x040041DF RID: 16863
	public float[] Triggers;

	// Token: 0x040041E0 RID: 16864
	public string[] Text;

	// Token: 0x040041E1 RID: 16865
	public UILabel WarningLabel;

	// Token: 0x040041E2 RID: 16866
	public UISprite Darkness;

	// Token: 0x040041E3 RID: 16867
	public UILabel Label;

	// Token: 0x040041E4 RID: 16868
	public bool FadeOut;

	// Token: 0x040041E5 RID: 16869
	public float Timer;

	// Token: 0x040041E6 RID: 16870
	public int ID;
}
