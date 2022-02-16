using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B6 RID: 1206
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F97 RID: 8087 RVA: 0x001BC06C File Offset: 0x001BA26C
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F98 RID: 8088 RVA: 0x001BC0E0 File Offset: 0x001BA2E0
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

	// Token: 0x040041E8 RID: 16872
	public float[] Triggers;

	// Token: 0x040041E9 RID: 16873
	public string[] Text;

	// Token: 0x040041EA RID: 16874
	public UILabel WarningLabel;

	// Token: 0x040041EB RID: 16875
	public UISprite Darkness;

	// Token: 0x040041EC RID: 16876
	public UILabel Label;

	// Token: 0x040041ED RID: 16877
	public bool FadeOut;

	// Token: 0x040041EE RID: 16878
	public float Timer;

	// Token: 0x040041EF RID: 16879
	public int ID;
}
