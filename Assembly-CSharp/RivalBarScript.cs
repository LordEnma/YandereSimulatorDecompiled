using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600210B RID: 8459 RVA: 0x001E3320 File Offset: 0x001E1520
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x001E3360 File Offset: 0x001E1560
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

	// Token: 0x0600210D RID: 8461 RVA: 0x001E34C0 File Offset: 0x001E16C0
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

	// Token: 0x04004886 RID: 18566
	public int ID;

	// Token: 0x04004887 RID: 18567
	public float Speed;

	// Token: 0x04004888 RID: 18568
	public float Timer;

	// Token: 0x04004889 RID: 18569
	public UISprite[] Bars;

	// Token: 0x0400488A RID: 18570
	public float[] TargetHeights;
}
