using System;
using UnityEngine;

// Token: 0x020003C2 RID: 962
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B2F RID: 6959 RVA: 0x0012F19C File Offset: 0x0012D39C
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

	// Token: 0x06001B30 RID: 6960 RVA: 0x0012F21C File Offset: 0x0012D41C
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B31 RID: 6961 RVA: 0x0012F224 File Offset: 0x0012D424
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

	// Token: 0x06001B32 RID: 6962 RVA: 0x0012F358 File Offset: 0x0012D558
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

	// Token: 0x06001B33 RID: 6963 RVA: 0x0012F400 File Offset: 0x0012D600
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

	// Token: 0x04002E3B RID: 11835
	public UISprite[] Button;

	// Token: 0x04002E3C RID: 11836
	public UILabel[] Label;

	// Token: 0x04002E3D RID: 11837
	public UILabel[] ButtonLabel;

	// Token: 0x04002E3E RID: 11838
	public UIPanel Panel;

	// Token: 0x04002E3F RID: 11839
	public bool Show;

	// Token: 0x04002E40 RID: 11840
	public int ID;
}
