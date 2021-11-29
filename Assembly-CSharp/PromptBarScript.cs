using System;
using UnityEngine;

// Token: 0x020003B9 RID: 953
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001AE9 RID: 6889 RVA: 0x0012A864 File Offset: 0x00128A64
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

	// Token: 0x06001AEA RID: 6890 RVA: 0x0012A8E4 File Offset: 0x00128AE4
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001AEB RID: 6891 RVA: 0x0012A8EC File Offset: 0x00128AEC
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

	// Token: 0x06001AEC RID: 6892 RVA: 0x0012AA20 File Offset: 0x00128C20
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

	// Token: 0x06001AED RID: 6893 RVA: 0x0012AAC8 File Offset: 0x00128CC8
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

	// Token: 0x04002D6F RID: 11631
	public UISprite[] Button;

	// Token: 0x04002D70 RID: 11632
	public UILabel[] Label;

	// Token: 0x04002D71 RID: 11633
	public UILabel[] ButtonLabel;

	// Token: 0x04002D72 RID: 11634
	public UIPanel Panel;

	// Token: 0x04002D73 RID: 11635
	public bool Show;

	// Token: 0x04002D74 RID: 11636
	public int ID;
}
