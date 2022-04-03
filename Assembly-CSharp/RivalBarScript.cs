using System;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x06002162 RID: 8546 RVA: 0x001EAF80 File Offset: 0x001E9180
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x06002163 RID: 8547 RVA: 0x001EAFC0 File Offset: 0x001E91C0
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

	// Token: 0x06002164 RID: 8548 RVA: 0x001EB120 File Offset: 0x001E9320
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

	// Token: 0x04004985 RID: 18821
	public int ID;

	// Token: 0x04004986 RID: 18822
	public float Speed;

	// Token: 0x04004987 RID: 18823
	public float Timer;

	// Token: 0x04004988 RID: 18824
	public UISprite[] Bars;

	// Token: 0x04004989 RID: 18825
	public float[] TargetHeights;
}
