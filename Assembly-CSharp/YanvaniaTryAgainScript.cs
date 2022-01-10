using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004E0 RID: 1248
public class YanvaniaTryAgainScript : MonoBehaviour
{
	// Token: 0x0600209A RID: 8346 RVA: 0x001DE68C File Offset: 0x001DC88C
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x0600209B RID: 8347 RVA: 0x001DE6A0 File Offset: 0x001DC8A0
	private void Update()
	{
		if (!this.FadeOut)
		{
			if (base.transform.localScale.x > 0.9f)
			{
				if (this.InputManager.TappedLeft)
				{
					this.Selected = 1;
				}
				if (this.InputManager.TappedRight)
				{
					this.Selected = 2;
				}
				if (this.Selected == 1)
				{
					this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, -100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
					this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, -1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
				}
				else
				{
					this.Highlight.localPosition = new Vector3(Mathf.Lerp(this.Highlight.localPosition.x, 100f, Time.deltaTime * 10f), this.Highlight.localPosition.y, this.Highlight.localPosition.z);
					this.Highlight.localScale = new Vector3(Mathf.Lerp(this.Highlight.localScale.x, 1f, Time.deltaTime * 10f), this.Highlight.localScale.y, this.Highlight.localScale.z);
				}
				if (Input.GetButtonDown("A") || Input.GetKeyDown("z") || Input.GetKeyDown("x"))
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ButtonEffect, this.Highlight.position, Quaternion.identity);
					gameObject.transform.parent = this.Highlight;
					gameObject.transform.localPosition = Vector3.zero;
					this.FadeOut = true;
					return;
				}
			}
		}
		else
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
			if (this.Darkness.color.a >= 1f)
			{
				if (this.Selected == 1)
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
					return;
				}
				SceneManager.LoadScene("YanvaniaTitleScene");
			}
		}
	}

	// Token: 0x0400477D RID: 18301
	public InputManagerScript InputManager;

	// Token: 0x0400477E RID: 18302
	public GameObject ButtonEffect;

	// Token: 0x0400477F RID: 18303
	public Transform Highlight;

	// Token: 0x04004780 RID: 18304
	public UISprite Darkness;

	// Token: 0x04004781 RID: 18305
	public bool FadeOut;

	// Token: 0x04004782 RID: 18306
	public int Selected = 1;
}
