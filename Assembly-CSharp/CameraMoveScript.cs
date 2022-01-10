using System;
using UnityEngine;

// Token: 0x02000512 RID: 1298
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600213A RID: 8506 RVA: 0x001E70DD File Offset: 0x001E52DD
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600213B RID: 8507 RVA: 0x001E710C File Offset: 0x001E530C
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.Begin = true;
		}
		if (this.Begin)
		{
			this.Timer += Time.deltaTime * this.Speed;
			if (this.Timer > 0.1f)
			{
				this.OpenDoors = true;
				if (this.LeftDoor != null)
				{
					this.LeftDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.LeftDoor.transform.localPosition.x, 1f, Time.deltaTime), this.LeftDoor.transform.localPosition.y, this.LeftDoor.transform.localPosition.z);
					this.RightDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.RightDoor.transform.localPosition.x, -1f, Time.deltaTime), this.RightDoor.transform.localPosition.y, this.RightDoor.transform.localPosition.z);
				}
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.EndPos.position, Time.deltaTime * this.Timer);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.EndPos.rotation, Time.deltaTime * this.Timer);
		}
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x001E729F File Offset: 0x001E549F
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040048E6 RID: 18662
	public Transform StartPos;

	// Token: 0x040048E7 RID: 18663
	public Transform EndPos;

	// Token: 0x040048E8 RID: 18664
	public Transform RightDoor;

	// Token: 0x040048E9 RID: 18665
	public Transform LeftDoor;

	// Token: 0x040048EA RID: 18666
	public Transform Target;

	// Token: 0x040048EB RID: 18667
	public bool OpenDoors;

	// Token: 0x040048EC RID: 18668
	public bool Begin;

	// Token: 0x040048ED RID: 18669
	public float Speed;

	// Token: 0x040048EE RID: 18670
	public float Timer;
}
