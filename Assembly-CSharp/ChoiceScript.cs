using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000245 RID: 581
public class ChoiceScript : MonoBehaviour
{
	// Token: 0x0600124D RID: 4685 RVA: 0x0008CAD0 File Offset: 0x0008ACD0
	private void Start()
	{
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x0600124E RID: 4686 RVA: 0x0008CAF8 File Offset: 0x0008ACF8
	private void Update()
	{
		this.Highlight.transform.localPosition = Vector3.Lerp(this.Highlight.transform.localPosition, new Vector3((float)(-360 + 720 * this.Selected), this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z), Time.deltaTime * 10f);
		if (this.Phase == 0)
		{
			this.Darkness.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 2f));
			if (this.Darkness.color.a == 0f)
			{
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 1)
		{
			if (this.InputManager.TappedLeft)
			{
				this.Darkness.color = new Color(1f, 1f, 1f, 0f);
				this.Selected = 0;
			}
			else if (this.InputManager.TappedRight)
			{
				this.Darkness.color = new Color(0f, 0f, 0f, 0f);
				this.Selected = 1;
			}
			if (Input.GetButtonDown("A"))
			{
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 2f));
			if (this.Darkness.color.a == 1f)
			{
				GameGlobals.LoveSick = (this.Selected == 1);
				SceneManager.LoadScene("NewTitleScene");
			}
		}
	}

	// Token: 0x04001721 RID: 5921
	public InputManagerScript InputManager;

	// Token: 0x04001722 RID: 5922
	public PromptBarScript PromptBar;

	// Token: 0x04001723 RID: 5923
	public Transform Highlight;

	// Token: 0x04001724 RID: 5924
	public UISprite Darkness;

	// Token: 0x04001725 RID: 5925
	public int Selected;

	// Token: 0x04001726 RID: 5926
	public int Phase;
}
