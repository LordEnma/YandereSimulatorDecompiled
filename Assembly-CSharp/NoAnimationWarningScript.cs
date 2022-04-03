using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037B RID: 891
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A17 RID: 6679 RVA: 0x00112056 File Offset: 0x00110256
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A18 RID: 6680 RVA: 0x0011207C File Offset: 0x0011027C
	private void Update()
	{
		if (!this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f && Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				return;
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("BusStopScene");
			}
		}
	}

	// Token: 0x04002A6C RID: 10860
	public UISprite Darkness;

	// Token: 0x04002A6D RID: 10861
	public bool FadeOut;

	// Token: 0x04002A6E RID: 10862
	public float Alpha;
}
