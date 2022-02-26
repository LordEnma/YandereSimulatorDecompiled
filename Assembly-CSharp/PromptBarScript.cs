using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B0D RID: 6925 RVA: 0x0012CDB4 File Offset: 0x0012AFB4
	private void Awake()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, -627f, base.transform.localPosition.z);
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.Label[this.ID].text = string.Empty;
			this.ID++;
		}
	}

	// Token: 0x06001B0E RID: 6926 RVA: 0x0012CE34 File Offset: 0x0012B034
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B0F RID: 6927 RVA: 0x0012CE3C File Offset: 0x0012B03C
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!this.Show)
		{
			if (this.Panel.enabled)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -628f, t), base.transform.localPosition.z);
				if (base.transform.localPosition.y < -627f)
				{
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, -628f, base.transform.localPosition.z);
					if (this.Panel != null)
					{
						this.Panel.enabled = false;
						return;
					}
				}
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -528.5f, t), base.transform.localPosition.z);
		}
	}

	// Token: 0x06001B10 RID: 6928 RVA: 0x0012CF70 File Offset: 0x0012B170
	public void UpdateButtons()
	{
		if (this.Panel != null)
		{
			this.Panel.enabled = true;
		}
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.Button[this.ID].enabled = (this.Label[this.ID].text.Length > 0);
			this.ButtonLabel[this.ID].enabled = (this.Label[this.ID].text.Length > 0);
			this.ID++;
		}
	}

	// Token: 0x06001B11 RID: 6929 RVA: 0x0012D018 File Offset: 0x0012B218
	public void ClearButtons()
	{
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.ButtonLabel[this.ID].enabled = false;
			this.Label[this.ID].text = string.Empty;
			this.Button[this.ID].enabled = false;
			this.ID++;
		}
	}

	// Token: 0x04002DC8 RID: 11720
	public UISprite[] Button;

	// Token: 0x04002DC9 RID: 11721
	public UILabel[] Label;

	// Token: 0x04002DCA RID: 11722
	public UILabel[] ButtonLabel;

	// Token: 0x04002DCB RID: 11723
	public UIPanel Panel;

	// Token: 0x04002DCC RID: 11724
	public bool Show;

	// Token: 0x04002DCD RID: 11725
	public int ID;
}
