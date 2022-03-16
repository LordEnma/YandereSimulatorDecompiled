using System;
using UnityEngine;

// Token: 0x02000389 RID: 905
public class OsanaReleaseDateScript : MonoBehaviour
{
	// Token: 0x06001A44 RID: 6724 RVA: 0x00117838 File Offset: 0x00115A38
	private void Start()
	{
		Time.timeScale = 1f;
		foreach (UISprite uisprite in this.BlackRectangles)
		{
			if (uisprite != null)
			{
				uisprite.alpha = 1f;
			}
		}
	}

	// Token: 0x06001A45 RID: 6725 RVA: 0x0011787C File Offset: 0x00115A7C
	private void Update()
	{
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (this.ChooseRectangle)
		{
			if (this.LettersRevealed < 33)
			{
				this.RandomID = UnityEngine.Random.Range(1, this.BlackRectangles.Length);
				for (;;)
				{
					if (this.BlackRectangles[this.RandomID].alpha != 0f)
					{
						if (this.RandomID <= 28)
						{
							break;
						}
						if (this.RandomID >= 34)
						{
							break;
						}
					}
					this.RandomID = UnityEngine.Random.Range(1, this.BlackRectangles.Length);
				}
			}
			else
			{
				this.RandomID = UnityEngine.Random.Range(28, 34);
				while (this.BlackRectangles[this.RandomID].alpha == 0f)
				{
					this.RandomID = UnityEngine.Random.Range(1, this.BlackRectangles.Length);
				}
			}
			this.ChooseRectangle = false;
			return;
		}
		this.BlackRectangles[this.RandomID].alpha = Mathf.MoveTowards(this.BlackRectangles[this.RandomID].alpha, 0f, Time.deltaTime * 0.6333333f);
		if (this.BlackRectangles[this.RandomID].alpha == 0f)
		{
			this.LettersRevealed++;
			if (this.LettersRevealed < 38)
			{
				this.ChooseRectangle = true;
				return;
			}
			base.enabled = false;
		}
	}

	// Token: 0x04002B19 RID: 11033
	public UISprite[] BlackRectangles;

	// Token: 0x04002B1A RID: 11034
	public bool ChooseRectangle = true;

	// Token: 0x04002B1B RID: 11035
	public int LettersRevealed;

	// Token: 0x04002B1C RID: 11036
	public int RandomID;
}
