using System;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600213A RID: 8506 RVA: 0x001E77A8 File Offset: 0x001E59A8
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600213B RID: 8507 RVA: 0x001E77E8 File Offset: 0x001E59E8
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

	// Token: 0x0600213C RID: 8508 RVA: 0x001E7948 File Offset: 0x001E5B48
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

	// Token: 0x040048F4 RID: 18676
	public int ID;

	// Token: 0x040048F5 RID: 18677
	public float Speed;

	// Token: 0x040048F6 RID: 18678
	public float Timer;

	// Token: 0x040048F7 RID: 18679
	public UISprite[] Bars;

	// Token: 0x040048F8 RID: 18680
	public float[] TargetHeights;
}
