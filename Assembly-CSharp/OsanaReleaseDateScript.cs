using System;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class OsanaReleaseDateScript : MonoBehaviour
{
	// Token: 0x06001A26 RID: 6694 RVA: 0x00115600 File Offset: 0x00113800
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

	// Token: 0x06001A27 RID: 6695 RVA: 0x00115644 File Offset: 0x00113844
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

	// Token: 0x04002ABA RID: 10938
	public UISprite[] BlackRectangles;

	// Token: 0x04002ABB RID: 10939
	public bool ChooseRectangle = true;

	// Token: 0x04002ABC RID: 10940
	public int LettersRevealed;

	// Token: 0x04002ABD RID: 10941
	public int RandomID;
}
