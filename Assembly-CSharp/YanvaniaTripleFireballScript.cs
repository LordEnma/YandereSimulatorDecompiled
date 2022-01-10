using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaTripleFireballScript : MonoBehaviour
{
	// Token: 0x06002097 RID: 8343 RVA: 0x001DE4BC File Offset: 0x001DC6BC
	private void Start()
	{
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x06002098 RID: 8344 RVA: 0x001DE4EC File Offset: 0x001DC6EC
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

	// Token: 0x04004778 RID: 18296
	public Transform[] Fireballs;

	// Token: 0x04004779 RID: 18297
	public Transform Dracula;

	// Token: 0x0400477A RID: 18298
	public int Direction;

	// Token: 0x0400477B RID: 18299
	public float Speed;

	// Token: 0x0400477C RID: 18300
	public float Timer;
}
