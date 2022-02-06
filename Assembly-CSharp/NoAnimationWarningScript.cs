using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000378 RID: 888
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019F6 RID: 6646 RVA: 0x0010FEEE File Offset: 0x0010E0EE
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019F7 RID: 6647 RVA: 0x0010FF14 File Offset: 0x0010E114
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

	// Token: 0x04002A05 RID: 10757
	public UISprite Darkness;

	// Token: 0x04002A06 RID: 10758
	public bool FadeOut;

	// Token: 0x04002A07 RID: 10759
	public float Alpha;
}
