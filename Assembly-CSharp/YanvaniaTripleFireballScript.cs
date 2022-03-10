using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaTripleFireballScript : MonoBehaviour
{
	// Token: 0x060020B8 RID: 8376 RVA: 0x001E19B4 File Offset: 0x001DFBB4
	private void Start()
	{
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x060020B9 RID: 8377 RVA: 0x001E19E4 File Offset: 0x001DFBE4
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

	// Token: 0x040047C9 RID: 18377
	public Transform[] Fireballs;

	// Token: 0x040047CA RID: 18378
	public Transform Dracula;

	// Token: 0x040047CB RID: 18379
	public int Direction;

	// Token: 0x040047CC RID: 18380
	public float Speed;

	// Token: 0x040047CD RID: 18381
	public float Timer;
}
