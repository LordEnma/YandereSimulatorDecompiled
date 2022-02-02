using System;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600211F RID: 8479 RVA: 0x001E5820 File Offset: 0x001E3A20
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x001E5860 File Offset: 0x001E3A60
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

	// Token: 0x06002121 RID: 8481 RVA: 0x001E59C0 File Offset: 0x001E3BC0
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

	// Token: 0x040048B5 RID: 18613
	public int ID;

	// Token: 0x040048B6 RID: 18614
	public float Speed;

	// Token: 0x040048B7 RID: 18615
	public float Timer;

	// Token: 0x040048B8 RID: 18616
	public UISprite[] Bars;

	// Token: 0x040048B9 RID: 18617
	public float[] TargetHeights;
}
