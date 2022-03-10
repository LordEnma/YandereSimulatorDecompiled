using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004B7 RID: 1207
public class WarningScript : MonoBehaviour
{
	// Token: 0x06001FA3 RID: 8099 RVA: 0x001BD358 File Offset: 0x001BB558
	private void Start()
	{
		this.WarningLabel.gameObject.SetActive(false);
		this.Label.text = string.Empty;
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001FA4 RID: 8100 RVA: 0x001BD3CC File Offset: 0x001BB5CC
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

	// Token: 0x0400420F RID: 16911
	public float[] Triggers;

	// Token: 0x04004210 RID: 16912
	public string[] Text;

	// Token: 0x04004211 RID: 16913
	public UILabel WarningLabel;

	// Token: 0x04004212 RID: 16914
	public UISprite Darkness;

	// Token: 0x04004213 RID: 16915
	public UILabel Label;

	// Token: 0x04004214 RID: 16916
	public bool FadeOut;

	// Token: 0x04004215 RID: 16917
	public float Timer;

	// Token: 0x04004216 RID: 16918
	public int ID;
}
