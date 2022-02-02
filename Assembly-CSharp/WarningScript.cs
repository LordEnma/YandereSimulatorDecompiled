using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B5 RID: 1205
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F8B RID: 8075 RVA: 0x001BB6EC File Offset: 0x001B98EC
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x001BB760 File Offset: 0x001B9960
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

	// Token: 0x040041D6 RID: 16854
	public float[] Triggers;

	// Token: 0x040041D7 RID: 16855
	public string[] Text;

	// Token: 0x040041D8 RID: 16856
	public UILabel WarningLabel;

	// Token: 0x040041D9 RID: 16857
	public UISprite Darkness;

	// Token: 0x040041DA RID: 16858
	public UILabel Label;

	// Token: 0x040041DB RID: 16859
	public bool FadeOut;

	// Token: 0x040041DC RID: 16860
	public float Timer;

	// Token: 0x040041DD RID: 16861
	public int ID;
}
