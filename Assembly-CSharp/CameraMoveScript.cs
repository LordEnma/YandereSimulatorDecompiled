using System;
using UnityEngine;

// Token: 0x02000522 RID: 1314
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x060021A6 RID: 8614 RVA: 0x001F1911 File Offset: 0x001EFB11
	private void Start()
	{
		base.transform.position = this.StartPos.position;
		base.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x060021A7 RID: 8615 RVA: 0x001F1940 File Offset: 0x001EFB40
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

	// Token: 0x060021A8 RID: 8616 RVA: 0x001F1AD3 File Offset: 0x001EFCD3
	private void LateUpdate()
	{
		if (this.Target != null)
		{
			base.transform.LookAt(this.Target);
		}
	}

	// Token: 0x04004A1B RID: 18971
	public Transform StartPos;

	// Token: 0x04004A1C RID: 18972
	public Transform EndPos;

	// Token: 0x04004A1D RID: 18973
	public Transform RightDoor;

	// Token: 0x04004A1E RID: 18974
	public Transform LeftDoor;

	// Token: 0x04004A1F RID: 18975
	public Transform Target;

	// Token: 0x04004A20 RID: 18976
	public bool OpenDoors;

	// Token: 0x04004A21 RID: 18977
	public bool Begin;

	// Token: 0x04004A22 RID: 18978
	public float Speed;

	// Token: 0x04004A23 RID: 18979
	public float Timer;
}
