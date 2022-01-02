using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaTripleFireballScript : MonoBehaviour
{
	// Token: 0x0600208C RID: 8332 RVA: 0x001DDB1C File Offset: 0x001DBD1C
	private void Start()
	{
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x0600208D RID: 8333 RVA: 0x001DDB4C File Offset: 0x001DBD4C
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

	// Token: 0x04004764 RID: 18276
	public Transform[] Fireballs;

	// Token: 0x04004765 RID: 18277
	public Transform Dracula;

	// Token: 0x04004766 RID: 18278
	public int Direction;

	// Token: 0x04004767 RID: 18279
	public float Speed;

	// Token: 0x04004768 RID: 18280
	public float Timer;
}
