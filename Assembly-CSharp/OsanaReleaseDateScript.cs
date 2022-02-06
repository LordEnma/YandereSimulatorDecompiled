using System;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class OsanaReleaseDateScript : MonoBehaviour
{
	// Token: 0x06001A29 RID: 6697 RVA: 0x00115C18 File Offset: 0x00113E18
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

	// Token: 0x06001A2A RID: 6698 RVA: 0x00115C5C File Offset: 0x00113E5C
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

	// Token: 0x04002AC4 RID: 10948
	public UISprite[] BlackRectangles;

	// Token: 0x04002AC5 RID: 10949
	public bool ChooseRectangle = true;

	// Token: 0x04002AC6 RID: 10950
	public int LettersRevealed;

	// Token: 0x04002AC7 RID: 10951
	public int RandomID;
}
