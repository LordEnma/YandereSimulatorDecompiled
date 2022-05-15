using System;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x06002185 RID: 8581 RVA: 0x001EEAE4 File Offset: 0x001ECCE4
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x06002186 RID: 8582 RVA: 0x001EEB24 File Offset: 0x001ECD24
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

	// Token: 0x06002187 RID: 8583 RVA: 0x001EEC84 File Offset: 0x001ECE84
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

	// Token: 0x040049D8 RID: 18904
	public int ID;

	// Token: 0x040049D9 RID: 18905
	public float Speed;

	// Token: 0x040049DA RID: 18906
	public float Timer;

	// Token: 0x040049DB RID: 18907
	public UISprite[] Bars;

	// Token: 0x040049DC RID: 18908
	public float[] TargetHeights;
}
