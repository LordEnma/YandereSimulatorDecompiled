using System;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600216A RID: 8554 RVA: 0x001EB4B0 File Offset: 0x001E96B0
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600216B RID: 8555 RVA: 0x001EB4F0 File Offset: 0x001E96F0
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

	// Token: 0x0600216C RID: 8556 RVA: 0x001EB650 File Offset: 0x001E9850
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

	// Token: 0x04004989 RID: 18825
	public int ID;

	// Token: 0x0400498A RID: 18826
	public float Speed;

	// Token: 0x0400498B RID: 18827
	public float Timer;

	// Token: 0x0400498C RID: 18828
	public UISprite[] Bars;

	// Token: 0x0400498D RID: 18829
	public float[] TargetHeights;
}
