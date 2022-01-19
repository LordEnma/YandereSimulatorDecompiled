using System;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600211B RID: 8475 RVA: 0x001E4F80 File Offset: 0x001E3180
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600211C RID: 8476 RVA: 0x001E4FC0 File Offset: 0x001E31C0
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.UpdateBars();
		}
		this.Timer += Time.deltaTime;
		if (this.ID < 11)
		{
			if (this.Timer > 1f)
			{
				this.UpdateBars();
				this.Timer = 0f;
			}
		}
		else if (this.Timer > 2.5f)
		{
			this.UpdateBars();
			this.Timer = 0f;
		}
		for (int i = 1; i < this.ID; i++)
		{
			this.Bars[i].transform.localScale = Vector3.Lerp(this.Bars[i].transform.localScale, new Vector3(1f, this.TargetHeights[i], 1f), Time.deltaTime * this.Speed);
			this.Bars[i].color = new Color(this.TargetHeights[i] / 7f, 1f - this.TargetHeights[i] / 7f, 0f);
			if (i == 1)
			{
				Debug.Log("R is: " + (this.TargetHeights[i] / 7f).ToString() + " G is: " + (1f - this.TargetHeights[i] / 7f).ToString());
			}
		}
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x001E5120 File Offset: 0x001E3320
	private void UpdateBars()
	{
		int i = 1;
		if (this.ID < 11)
		{
			this.ID++;
			return;
		}
		while (i < this.ID)
		{
			this.TargetHeights[i] = UnityEngine.Random.Range(0.7f, 7f);
			i++;
		}
	}

	// Token: 0x040048AA RID: 18602
	public int ID;

	// Token: 0x040048AB RID: 18603
	public float Speed;

	// Token: 0x040048AC RID: 18604
	public float Timer;

	// Token: 0x040048AD RID: 18605
	public UISprite[] Bars;

	// Token: 0x040048AE RID: 18606
	public float[] TargetHeights;
}
