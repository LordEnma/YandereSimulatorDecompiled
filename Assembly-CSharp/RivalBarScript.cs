using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600210E RID: 8462 RVA: 0x001E3910 File Offset: 0x001E1B10
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x001E3950 File Offset: 0x001E1B50
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

	// Token: 0x06002110 RID: 8464 RVA: 0x001E3AB0 File Offset: 0x001E1CB0
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

	// Token: 0x0400488F RID: 18575
	public int ID;

	// Token: 0x04004890 RID: 18576
	public float Speed;

	// Token: 0x04004891 RID: 18577
	public float Timer;

	// Token: 0x04004892 RID: 18578
	public UISprite[] Bars;

	// Token: 0x04004893 RID: 18579
	public float[] TargetHeights;
}
