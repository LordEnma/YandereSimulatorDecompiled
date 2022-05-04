using System;
using UnityEngine;

// Token: 0x0200038B RID: 907
public class OsanaReleaseDateScript : MonoBehaviour
{
	// Token: 0x06001A58 RID: 6744 RVA: 0x0011886C File Offset: 0x00116A6C
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

	// Token: 0x06001A59 RID: 6745 RVA: 0x001188B0 File Offset: 0x00116AB0
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

	// Token: 0x04002B40 RID: 11072
	public UISprite[] BlackRectangles;

	// Token: 0x04002B41 RID: 11073
	public bool ChooseRectangle = true;

	// Token: 0x04002B42 RID: 11074
	public int LettersRevealed;

	// Token: 0x04002B43 RID: 11075
	public int RandomID;
}
