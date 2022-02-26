using System;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x06002134 RID: 8500 RVA: 0x001E6DD0 File Offset: 0x001E4FD0
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x06002135 RID: 8501 RVA: 0x001E6E10 File Offset: 0x001E5010
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

	// Token: 0x06002136 RID: 8502 RVA: 0x001E6F70 File Offset: 0x001E5170
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

	// Token: 0x040048D7 RID: 18647
	public int ID;

	// Token: 0x040048D8 RID: 18648
	public float Speed;

	// Token: 0x040048D9 RID: 18649
	public float Timer;

	// Token: 0x040048DA RID: 18650
	public UISprite[] Bars;

	// Token: 0x040048DB RID: 18651
	public float[] TargetHeights;
}
