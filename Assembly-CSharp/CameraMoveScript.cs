using System;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x06002155 RID: 8533 RVA: 0x001E9BFD File Offset: 0x001E7DFD
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x001E9C2C File Offset: 0x001E7E2C
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

	// Token: 0x06002157 RID: 8535 RVA: 0x001E9DBF File Offset: 0x001E7FBF
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x0400491A RID: 18714
	public Transform StartPos;

	// Token: 0x0400491B RID: 18715
	public Transform EndPos;

	// Token: 0x0400491C RID: 18716
	public Transform RightDoor;

	// Token: 0x0400491D RID: 18717
	public Transform LeftDoor;

	// Token: 0x0400491E RID: 18718
	public Transform Target;

	// Token: 0x0400491F RID: 18719
	public bool OpenDoors;

	// Token: 0x04004920 RID: 18720
	public bool Begin;

	// Token: 0x04004921 RID: 18721
	public float Speed;

	// Token: 0x04004922 RID: 18722
	public float Timer;
}
