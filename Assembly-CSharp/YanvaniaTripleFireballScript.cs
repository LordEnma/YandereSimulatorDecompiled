using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaTripleFireballScript : MonoBehaviour
{
	// Token: 0x0600209F RID: 8351 RVA: 0x001DFD44 File Offset: 0x001DDF44
	private void Start()
	{
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x060020A0 RID: 8352 RVA: 0x001DFD74 File Offset: 0x001DDF74
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

	// Token: 0x04004790 RID: 18320
	public Transform[] Fireballs;

	// Token: 0x04004791 RID: 18321
	public Transform Dracula;

	// Token: 0x04004792 RID: 18322
	public int Direction;

	// Token: 0x04004793 RID: 18323
	public float Speed;

	// Token: 0x04004794 RID: 18324
	public float Timer;
}
