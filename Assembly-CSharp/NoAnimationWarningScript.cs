using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037A RID: 890
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A11 RID: 6673 RVA: 0x001119FE File Offset: 0x0010FBFE
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A12 RID: 6674 RVA: 0x00111A24 File Offset: 0x0010FC24
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

	// Token: 0x04002A59 RID: 10841
	public UISprite Darkness;

	// Token: 0x04002A5A RID: 10842
	public bool FadeOut;

	// Token: 0x04002A5B RID: 10843
	public float Alpha;
}
