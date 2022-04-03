using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B21 RID: 6945 RVA: 0x0012E5CC File Offset: 0x0012C7CC
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

	// Token: 0x06001B22 RID: 6946 RVA: 0x0012E64C File Offset: 0x0012C84C
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B23 RID: 6947 RVA: 0x0012E654 File Offset: 0x0012C854
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

	// Token: 0x06001B24 RID: 6948 RVA: 0x0012E788 File Offset: 0x0012C988
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

	// Token: 0x06001B25 RID: 6949 RVA: 0x0012E830 File Offset: 0x0012CA30
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

	// Token: 0x04002E24 RID: 11812
	public UISprite[] Button;

	// Token: 0x04002E25 RID: 11813
	public UILabel[] Label;

	// Token: 0x04002E26 RID: 11814
	public UILabel[] ButtonLabel;

	// Token: 0x04002E27 RID: 11815
	public UIPanel Panel;

	// Token: 0x04002E28 RID: 11816
	public bool Show;

	// Token: 0x04002E29 RID: 11817
	public int ID;
}
