using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004C1 RID: 1217
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001FE3 RID: 8163 RVA: 0x001C3A50 File Offset: 0x001C1C50
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001FE4 RID: 8164 RVA: 0x001C3AC4 File Offset: 0x001C1CC4
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

	// Token: 0x040042D9 RID: 17113
	public float[] Triggers;

	// Token: 0x040042DA RID: 17114
	public string[] Text;

	// Token: 0x040042DB RID: 17115
	public UILabel WarningLabel;

	// Token: 0x040042DC RID: 17116
	public UISprite Darkness;

	// Token: 0x040042DD RID: 17117
	public UILabel Label;

	// Token: 0x040042DE RID: 17118
	public bool FadeOut;

	// Token: 0x040042DF RID: 17119
	public float Timer;

	// Token: 0x040042E0 RID: 17120
	public int ID;
}
