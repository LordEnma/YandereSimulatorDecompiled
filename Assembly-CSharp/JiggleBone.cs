using System;
using UnityEngine;

// Token: 0x02000341 RID: 833
public class JiggleBone : MonoBehaviour
{
	// Token: 0x06001909 RID: 6409 RVA: 0x000FB668 File Offset: 0x000F9868
	private void Awake()
	{
		Vector3 vector = base.transform.position + base.transform.TransformDirection(this.boneAxis * this.targetDistance);
		this.dynamicPos = vector;
	}

	// Token: 0x0600190A RID: 6410 RVA: 0x000FB6AC File Offset: 0x000F98AC
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

	// Token: 0x04002753 RID: 10067
	public bool debugMode = true;

	// Token: 0x04002754 RID: 10068
	private Vector3 dynamicPos;

	// Token: 0x04002755 RID: 10069
	public Vector3 boneAxis = new Vector3(0f, 0f, 1f);

	// Token: 0x04002756 RID: 10070
	public float targetDistance = 2f;

	// Token: 0x04002757 RID: 10071
	public float bStiffness = 0.1f;

	// Token: 0x04002758 RID: 10072
	public float bMass = 0.9f;

	// Token: 0x04002759 RID: 10073
	public float bDamping = 0.75f;

	// Token: 0x0400275A RID: 10074
	public float bGravity = 0.75f;

	// Token: 0x0400275B RID: 10075
	private Vector3 force;

	// Token: 0x0400275C RID: 10076
	private Vector3 acc;

	// Token: 0x0400275D RID: 10077
	private Vector3 vel;

	// Token: 0x0400275E RID: 10078
	public bool SquashAndStretch = true;

	// Token: 0x0400275F RID: 10079
	public float sideStretch = 0.15f;

	// Token: 0x04002760 RID: 10080
	public float frontStretch = 0.2f;
}
