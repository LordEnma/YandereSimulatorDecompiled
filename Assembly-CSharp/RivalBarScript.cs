using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x06002119 RID: 8473 RVA: 0x001E42B0 File Offset: 0x001E24B0
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600211A RID: 8474 RVA: 0x001E42F0 File Offset: 0x001E24F0
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

	// Token: 0x0600211B RID: 8475 RVA: 0x001E4450 File Offset: 0x001E2650
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

	// Token: 0x040048A3 RID: 18595
	public int ID;

	// Token: 0x040048A4 RID: 18596
	public float Speed;

	// Token: 0x040048A5 RID: 18597
	public float Timer;

	// Token: 0x040048A6 RID: 18598
	public UISprite[] Bars;

	// Token: 0x040048A7 RID: 18599
	public float[] TargetHeights;
}
