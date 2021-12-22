using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B2 RID: 1202
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001F79 RID: 8057 RVA: 0x001B969C File Offset: 0x001B789C
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001B9710 File Offset: 0x001B7910
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

	// Token: 0x040041AC RID: 16812
	public float[] Triggers;

	// Token: 0x040041AD RID: 16813
	public string[] Text;

	// Token: 0x040041AE RID: 16814
	public UILabel WarningLabel;

	// Token: 0x040041AF RID: 16815
	public UISprite Darkness;

	// Token: 0x040041B0 RID: 16816
	public UILabel Label;

	// Token: 0x040041B1 RID: 16817
	public bool FadeOut;

	// Token: 0x040041B2 RID: 16818
	public float Timer;

	// Token: 0x040041B3 RID: 16819
	public int ID;
}
