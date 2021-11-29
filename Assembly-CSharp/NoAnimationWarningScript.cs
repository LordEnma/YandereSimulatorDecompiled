using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000376 RID: 886
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019E5 RID: 6629 RVA: 0x0010E80E File Offset: 0x0010CA0E
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019E6 RID: 6630 RVA: 0x0010E834 File Offset: 0x0010CA34
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

	// Token: 0x040029C8 RID: 10696
	public UISprite Darkness;

	// Token: 0x040029C9 RID: 10697
	public bool FadeOut;

	// Token: 0x040029CA RID: 10698
	public float Alpha;
}
