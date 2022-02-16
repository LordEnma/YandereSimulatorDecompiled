using System;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600212B RID: 8491 RVA: 0x001E61F0 File Offset: 0x001E43F0
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x001E6230 File Offset: 0x001E4430
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

	// Token: 0x0600212D RID: 8493 RVA: 0x001E6390 File Offset: 0x001E4590
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

	// Token: 0x040048C7 RID: 18631
	public int ID;

	// Token: 0x040048C8 RID: 18632
	public float Speed;

	// Token: 0x040048C9 RID: 18633
	public float Timer;

	// Token: 0x040048CA RID: 18634
	public UISprite[] Bars;

	// Token: 0x040048CB RID: 18635
	public float[] TargetHeights;
}
