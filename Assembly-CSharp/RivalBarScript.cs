using System;
using UnityEngine;

// Token: 0x0200050F RID: 1295
public class RivalBarScript : MonoBehaviour
{
	// Token: 0x0600217A RID: 8570 RVA: 0x001ED398 File Offset: 0x001EB598
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Bars[i].transform.localScale = new Vector3(1f, 0f, 1f);
		}
	}

	// Token: 0x0600217B RID: 8571 RVA: 0x001ED3D8 File Offset: 0x001EB5D8
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

	// Token: 0x0600217C RID: 8572 RVA: 0x001ED538 File Offset: 0x001EB738
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

	// Token: 0x040049B1 RID: 18865
	public int ID;

	// Token: 0x040049B2 RID: 18866
	public float Speed;

	// Token: 0x040049B3 RID: 18867
	public float Timer;

	// Token: 0x040049B4 RID: 18868
	public UISprite[] Bars;

	// Token: 0x040049B5 RID: 18869
	public float[] TargetHeights;
}
