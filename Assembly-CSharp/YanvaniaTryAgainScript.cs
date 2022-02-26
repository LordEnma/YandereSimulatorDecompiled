using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004E3 RID: 1251
public class YanvaniaTryAgainScript : MonoBehaviour
{
	// Token: 0x060020B5 RID: 8373 RVA: 0x001E11AC File Offset: 0x001DF3AC
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x060020B6 RID: 8374 RVA: 0x001E11C0 File Offset: 0x001DF3C0
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

	// Token: 0x040047B1 RID: 18353
	public InputManagerScript InputManager;

	// Token: 0x040047B2 RID: 18354
	public GameObject ButtonEffect;

	// Token: 0x040047B3 RID: 18355
	public Transform Highlight;

	// Token: 0x040047B4 RID: 18356
	public UISprite Darkness;

	// Token: 0x040047B5 RID: 18357
	public bool FadeOut;

	// Token: 0x040047B6 RID: 18358
	public int Selected = 1;
}
