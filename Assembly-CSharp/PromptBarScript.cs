using System;
using UnityEngine;

// Token: 0x020003C2 RID: 962
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B27 RID: 6951 RVA: 0x0012E778 File Offset: 0x0012C978
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

	// Token: 0x06001B28 RID: 6952 RVA: 0x0012E7F8 File Offset: 0x0012C9F8
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B29 RID: 6953 RVA: 0x0012E800 File Offset: 0x0012CA00
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

	// Token: 0x06001B2A RID: 6954 RVA: 0x0012E934 File Offset: 0x0012CB34
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

	// Token: 0x06001B2B RID: 6955 RVA: 0x0012E9DC File Offset: 0x0012CBDC
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

	// Token: 0x04002E27 RID: 11815
	public UISprite[] Button;

	// Token: 0x04002E28 RID: 11816
	public UILabel[] Label;

	// Token: 0x04002E29 RID: 11817
	public UILabel[] ButtonLabel;

	// Token: 0x04002E2A RID: 11818
	public UIPanel Panel;

	// Token: 0x04002E2B RID: 11819
	public bool Show;

	// Token: 0x04002E2C RID: 11820
	public int ID;
}
