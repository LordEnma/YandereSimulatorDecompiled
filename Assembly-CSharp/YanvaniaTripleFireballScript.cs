using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaTripleFireballScript : MonoBehaviour
{
	// Token: 0x06002089 RID: 8329 RVA: 0x001DD52C File Offset: 0x001DB72C
	private void Start()
	{
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x0600208A RID: 8330 RVA: 0x001DD55C File Offset: 0x001DB75C
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

	// Token: 0x0400475B RID: 18267
	public Transform[] Fireballs;

	// Token: 0x0400475C RID: 18268
	public Transform Dracula;

	// Token: 0x0400475D RID: 18269
	public int Direction;

	// Token: 0x0400475E RID: 18270
	public float Speed;

	// Token: 0x0400475F RID: 18271
	public float Timer;
}
