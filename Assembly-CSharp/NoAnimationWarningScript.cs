using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200037C RID: 892
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x06001A21 RID: 6689 RVA: 0x00112486 File Offset: 0x00110686
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x06001A22 RID: 6690 RVA: 0x001124AC File Offset: 0x001106AC
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

	// Token: 0x04002A77 RID: 10871
	public UISprite Darkness;

	// Token: 0x04002A78 RID: 10872
	public bool FadeOut;

	// Token: 0x04002A79 RID: 10873
	public float Alpha;
}
