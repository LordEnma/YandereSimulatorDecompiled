using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B1 RID: 1201
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F6F RID: 8047 RVA: 0x001B88E0 File Offset: 0x001B6AE0
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x001B8954 File Offset: 0x001B6B54
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

	// Token: 0x0400417C RID: 16764
	public float[] Triggers;

	// Token: 0x0400417D RID: 16765
	public string[] Text;

	// Token: 0x0400417E RID: 16766
	public UILabel WarningLabel;

	// Token: 0x0400417F RID: 16767
	public UISprite Darkness;

	// Token: 0x04004180 RID: 16768
	public UILabel Label;

	// Token: 0x04004181 RID: 16769
	public bool FadeOut;

	// Token: 0x04004182 RID: 16770
	public float Timer;

	// Token: 0x04004183 RID: 16771
	public int ID;
}
