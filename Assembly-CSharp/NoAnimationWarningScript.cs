using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037C RID: 892
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A25 RID: 6693 RVA: 0x00112952 File Offset: 0x00110B52
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A26 RID: 6694 RVA: 0x00112978 File Offset: 0x00110B78
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

	// Token: 0x04002A80 RID: 10880
	public UISprite Darkness;

	// Token: 0x04002A81 RID: 10881
	public bool FadeOut;

	// Token: 0x04002A82 RID: 10882
	public float Alpha;
}
