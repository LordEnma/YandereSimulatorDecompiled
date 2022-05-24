using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B36 RID: 6966 RVA: 0x0012FFA8 File Offset: 0x0012E1A8
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

	// Token: 0x06001B37 RID: 6967 RVA: 0x00130028 File Offset: 0x0012E228
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x00130030 File Offset: 0x0012E230
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

	// Token: 0x06001B39 RID: 6969 RVA: 0x00130164 File Offset: 0x0012E364
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

	// Token: 0x06001B3A RID: 6970 RVA: 0x0013020C File Offset: 0x0012E40C
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

	// Token: 0x04002E58 RID: 11864
	public UISprite[] Button;

	// Token: 0x04002E59 RID: 11865
	public UILabel[] Label;

	// Token: 0x04002E5A RID: 11866
	public UILabel[] ButtonLabel;

	// Token: 0x04002E5B RID: 11867
	public UIPanel Panel;

	// Token: 0x04002E5C RID: 11868
	public bool Show;

	// Token: 0x04002E5D RID: 11869
	public int ID;
}
