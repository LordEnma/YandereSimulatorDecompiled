using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000244 RID: 580
public class ChoiceScript : MonoBehaviour
{
	// Token: 0x06001249 RID: 4681 RVA: 0x0008C52C File Offset: 0x0008A72C
	private void Start()
	{
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x0600124A RID: 4682 RVA: 0x0008C554 File Offset: 0x0008A754
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

	// Token: 0x04001710 RID: 5904
	public InputManagerScript InputManager;

	// Token: 0x04001711 RID: 5905
	public PromptBarScript PromptBar;

	// Token: 0x04001712 RID: 5906
	public Transform Highlight;

	// Token: 0x04001713 RID: 5907
	public UISprite Darkness;

	// Token: 0x04001714 RID: 5908
	public int Selected;

	// Token: 0x04001715 RID: 5909
	public int Phase;
}
