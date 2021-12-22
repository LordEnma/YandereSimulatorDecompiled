using System;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600212C RID: 8492 RVA: 0x001E614D File Offset: 0x001E434D
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x001E617C File Offset: 0x001E437C
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

	// Token: 0x0600212E RID: 8494 RVA: 0x001E630F File Offset: 0x001E450F
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x040048C9 RID: 18633
	public Transform StartPos;

	// Token: 0x040048CA RID: 18634
	public Transform EndPos;

	// Token: 0x040048CB RID: 18635
	public Transform RightDoor;

	// Token: 0x040048CC RID: 18636
	public Transform LeftDoor;

	// Token: 0x040048CD RID: 18637
	public Transform Target;

	// Token: 0x040048CE RID: 18638
	public bool OpenDoors;

	// Token: 0x040048CF RID: 18639
	public bool Begin;

	// Token: 0x040048D0 RID: 18640
	public float Speed;

	// Token: 0x040048D1 RID: 18641
	public float Timer;
}
