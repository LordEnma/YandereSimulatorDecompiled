using System;
using UnityEngine;

// Token: 0x02000388 RID: 904
public class OsanaReleaseDateScript : MonoBehaviour
{
	// Token: 0x06001A30 RID: 6704 RVA: 0x00115F3C File Offset: 0x0011413C
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

	// Token: 0x06001A31 RID: 6705 RVA: 0x00115F80 File Offset: 0x00114180
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

	// Token: 0x04002ACA RID: 10954
	public UISprite[] BlackRectangles;

	// Token: 0x04002ACB RID: 10955
	public bool ChooseRectangle = true;

	// Token: 0x04002ACC RID: 10956
	public int LettersRevealed;

	// Token: 0x04002ACD RID: 10957
	public int RandomID;
}
