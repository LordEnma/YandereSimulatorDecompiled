using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B5 RID: 1205
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F89 RID: 8073 RVA: 0x001BB1C4 File Offset: 0x001B93C4
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F8A RID: 8074 RVA: 0x001BB238 File Offset: 0x001B9438
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

	// Token: 0x040041CE RID: 16846
	public float[] Triggers;

	// Token: 0x040041CF RID: 16847
	public string[] Text;

	// Token: 0x040041D0 RID: 16848
	public UILabel WarningLabel;

	// Token: 0x040041D1 RID: 16849
	public UISprite Darkness;

	// Token: 0x040041D2 RID: 16850
	public UILabel Label;

	// Token: 0x040041D3 RID: 16851
	public bool FadeOut;

	// Token: 0x040041D4 RID: 16852
	public float Timer;

	// Token: 0x040041D5 RID: 16853
	public int ID;
}
