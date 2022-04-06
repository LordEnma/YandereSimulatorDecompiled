using System;
using UnityEngine;

// Token: 0x02000343 RID: 835
public class JiggleBone : MonoBehaviour
{
	// Token: 0x06001915 RID: 6421 RVA: 0x000FBDF4 File Offset: 0x000F9FF4
	private void Awake()
	{
		Vector3 vector = base.transform.position + base.transform.TransformDirection(this.boneAxis * this.targetDistance);
		this.dynamicPos = vector;
	}

	// Token: 0x06001916 RID: 6422 RVA: 0x000FBE38 File Offset: 0x000FA038
	private void LateUpdate()
	{
		base.transform.rotation = default(Quaternion);
		Vector3 dir = base.transform.TransformDirection(this.boneAxis * this.targetDistance);
		Vector3 vector = base.transform.TransformDirection(new Vector3(0f, 1f, 0f));
		Vector3 vector2 = base.transform.position + base.transform.TransformDirection(this.boneAxis * this.targetDistance);
		this.force.x = (vector2.x - this.dynamicPos.x) * this.bStiffness;
		this.acc.x = this.force.x / this.bMass;
		this.vel.x = this.vel.x + this.acc.x * (1f - this.bDamping);
		this.force.y = (vector2.y - this.dynamicPos.y) * this.bStiffness;
		this.force.y = this.force.y - this.bGravity / 10f;
		this.acc.y = this.force.y / this.bMass;
		this.vel.y = this.vel.y + this.acc.y * (1f - this.bDamping);
		this.force.z = (vector2.z - this.dynamicPos.z) * this.bStiffness;
		this.acc.z = this.force.z / this.bMass;
		this.vel.z = this.vel.z + this.acc.z * (1f - this.bDamping);
		this.dynamicPos += this.vel + this.force;
		base.transform.LookAt(this.dynamicPos, vector);
		if (this.SquashAndStretch)
		{
			float magnitude = (this.dynamicPos - vector2).magnitude;
			if (this.boneAxis.x != 0f)
			{
				float num = this.frontStretch;
			}
			else
			{
				float num2 = this.sideStretch;
			}
			if (this.boneAxis.y != 0f)
			{
				float num3 = this.frontStretch;
			}
			else
			{
				float num4 = this.sideStretch;
			}
			if (this.boneAxis.z != 0f)
			{
				float num5 = this.frontStretch;
			}
			else
			{
				float num6 = this.sideStretch;
			}
		}
		if (this.debugMode)
		{
			Debug.DrawRay(base.transform.position, dir, Color.blue);
			Debug.DrawRay(base.transform.position, vector, Color.green);
			Debug.DrawRay(vector2, Vector3.up * 0.2f, Color.yellow);
			Debug.DrawRay(this.dynamicPos, Vector3.up * 0.2f, Color.red);
		}
	}

	// Token: 0x04002769 RID: 10089
	public bool debugMode = true;

	// Token: 0x0400276A RID: 10090
	private Vector3 dynamicPos;

	// Token: 0x0400276B RID: 10091
	public Vector3 boneAxis = new Vector3(0f, 0f, 1f);

	// Token: 0x0400276C RID: 10092
	public float targetDistance = 2f;

	// Token: 0x0400276D RID: 10093
	public float bStiffness = 0.1f;

	// Token: 0x0400276E RID: 10094
	public float bMass = 0.9f;

	// Token: 0x0400276F RID: 10095
	public float bDamping = 0.75f;

	// Token: 0x04002770 RID: 10096
	public float bGravity = 0.75f;

	// Token: 0x04002771 RID: 10097
	private Vector3 force;

	// Token: 0x04002772 RID: 10098
	private Vector3 acc;

	// Token: 0x04002773 RID: 10099
	private Vector3 vel;

	// Token: 0x04002774 RID: 10100
	public bool SquashAndStretch = true;

	// Token: 0x04002775 RID: 10101
	public float sideStretch = 0.15f;

	// Token: 0x04002776 RID: 10102
	public float frontStretch = 0.2f;
}
