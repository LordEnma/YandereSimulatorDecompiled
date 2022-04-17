using System;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x06002171 RID: 8561 RVA: 0x001EBF0C File Offset: 0x001EA10C
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x06002172 RID: 8562 RVA: 0x001EBF4C File Offset: 0x001EA14C
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

	// Token: 0x06002173 RID: 8563 RVA: 0x001EC0AC File Offset: 0x001EA2AC
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

	// Token: 0x0400499B RID: 18843
	public int ID;

	// Token: 0x0400499C RID: 18844
	public float Speed;

	// Token: 0x0400499D RID: 18845
	public float Timer;

	// Token: 0x0400499E RID: 18846
	public UISprite[] Bars;

	// Token: 0x0400499F RID: 18847
	public float[] TargetHeights;
}
