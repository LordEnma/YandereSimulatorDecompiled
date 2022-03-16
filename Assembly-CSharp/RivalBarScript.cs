using System;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x06002152 RID: 8530 RVA: 0x001E9710 File Offset: 0x001E7910
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x001E9750 File Offset: 0x001E7950
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

	// Token: 0x06002154 RID: 8532 RVA: 0x001E98B0 File Offset: 0x001E7AB0
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

	// Token: 0x04004953 RID: 18771
	public int ID;

	// Token: 0x04004954 RID: 18772
	public float Speed;

	// Token: 0x04004955 RID: 18773
	public float Timer;

	// Token: 0x04004956 RID: 18774
	public UISprite[] Bars;

	// Token: 0x04004957 RID: 18775
	public float[] TargetHeights;
}
