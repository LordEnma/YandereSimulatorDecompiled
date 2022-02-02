using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaTripleFireballScript : MonoBehaviour
{
	// Token: 0x0600209D RID: 8349 RVA: 0x001DFA2C File Offset: 0x001DDC2C
	private void Start()
	{
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x0600209E RID: 8350 RVA: 0x001DFA5C File Offset: 0x001DDC5C
	private void Update()
	{
		Transform transform = this.Fireballs[1];
		Transform transform2 = this.Fireballs[2];
		Transform transform3 = this.Fireballs[3];
		if (transform != null)
		{
			transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, 7.5f, Time.deltaTime * this.Speed), transform.position.z);
		}
		if (transform2 != null)
		{
			transform2.position = new Vector3(transform2.position.x, Mathf.MoveTowards(transform2.position.y, 7.16666f, Time.deltaTime * this.Speed), transform2.position.z);
		}
		if (transform3 != null)
		{
			transform3.position = new Vector3(transform3.position.x, Mathf.MoveTowards(transform3.position.y, 6.83333f, Time.deltaTime * this.Speed), transform3.position.z);
		}
		for (int i = 1; i < 4; i++)
		{
			Transform transform4 = this.Fireballs[i];
			if (transform4 != null)
			{
				transform4.position = new Vector3(transform4.position.x + (float)this.Direction * Time.deltaTime * this.Speed, transform4.position.y, transform4.position.z);
			}
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 10f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400478A RID: 18314
	public Transform[] Fireballs;

	// Token: 0x0400478B RID: 18315
	public Transform Dracula;

	// Token: 0x0400478C RID: 18316
	public int Direction;

	// Token: 0x0400478D RID: 18317
	public float Speed;

	// Token: 0x0400478E RID: 18318
	public float Timer;
}
