using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C0 RID: 1216
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001FD9 RID: 8153 RVA: 0x001C243C File Offset: 0x001C063C
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001FDA RID: 8154 RVA: 0x001C24B0 File Offset: 0x001C06B0
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

	// Token: 0x040042B2 RID: 17074
	public float[] Triggers;

	// Token: 0x040042B3 RID: 17075
	public string[] Text;

	// Token: 0x040042B4 RID: 17076
	public UILabel WarningLabel;

	// Token: 0x040042B5 RID: 17077
	public UISprite Darkness;

	// Token: 0x040042B6 RID: 17078
	public UILabel Label;

	// Token: 0x040042B7 RID: 17079
	public bool FadeOut;

	// Token: 0x040042B8 RID: 17080
	public float Timer;

	// Token: 0x040042B9 RID: 17081
	public int ID;
}
