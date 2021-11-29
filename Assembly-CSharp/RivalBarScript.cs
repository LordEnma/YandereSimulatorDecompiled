using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x060020FA RID: 8442 RVA: 0x001E1BEC File Offset: 0x001DFDEC
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E1C2C File Offset: 0x001DFE2C
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

	// Token: 0x060020FC RID: 8444 RVA: 0x001E1D8C File Offset: 0x001DFF8C
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

	// Token: 0x04004847 RID: 18503
	public int ID;

	// Token: 0x04004848 RID: 18504
	public float Speed;

	// Token: 0x04004849 RID: 18505
	public float Timer;

	// Token: 0x0400484A RID: 18506
	public UISprite[] Bars;

	// Token: 0x0400484B RID: 18507
	public float[] TargetHeights;
}
