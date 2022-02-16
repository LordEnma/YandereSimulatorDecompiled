using System;
using UnityEngine;

// Token: 0x02000514 RID: 1300
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x0600214C RID: 8524 RVA: 0x001E901D File Offset: 0x001E721D
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x001E904C File Offset: 0x001E724C
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

	// Token: 0x0600214E RID: 8526 RVA: 0x001E91DF File Offset: 0x001E73DF
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x0400490A RID: 18698
	public Transform StartPos;

	// Token: 0x0400490B RID: 18699
	public Transform EndPos;

	// Token: 0x0400490C RID: 18700
	public Transform RightDoor;

	// Token: 0x0400490D RID: 18701
	public Transform LeftDoor;

	// Token: 0x0400490E RID: 18702
	public Transform Target;

	// Token: 0x0400490F RID: 18703
	public bool OpenDoors;

	// Token: 0x04004910 RID: 18704
	public bool Begin;

	// Token: 0x04004911 RID: 18705
	public float Speed;

	// Token: 0x04004912 RID: 18706
	public float Timer;
}
