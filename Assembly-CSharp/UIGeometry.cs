using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000081 RID: 129
public class UIGeometry
{
	// Token: 0x1700008B RID: 139
	// (get) Token: 0x060004CD RID: 1229 RVA: 0x00030E28 File Offset: 0x0002F028
	public bool hasVertices
	{
		get
		{
			return this.verts.Count > 0;
		}
	}

	// Token: 0x1700008C RID: 140
	// (get) Token: 0x060004CE RID: 1230 RVA: 0x00030E38 File Offset: 0x0002F038
	public bool hasTransformed
	{
		get
		{
			return this.mRtpVerts != null && this.mRtpVerts.Count > 0 && this.mRtpVerts.Count == this.verts.Count;
		}
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x00030E6A File Offset: 0x0002F06A
	public void Clear()
	{
		this.verts.Clear();
		this.uvs.Clear();
		this.cols.Clear();
		this.mRtpVerts.Clear();
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x00030E98 File Offset: 0x0002F098
	public void ApplyTransform(Matrix4x4 widgetToPanel, bool generateNormals = true)
	{
		if (this.verts.Count > 0)
		{
			this.mRtpVerts.Clear();
			int i = 0;
			int count = this.verts.Count;
			while (i < count)
			{
				this.mRtpVerts.Add(widgetToPanel.MultiplyPoint3x4(this.verts[i]));
				i++;
			}
			if (generateNormals)
			{
				this.mRtpNormal = widgetToPanel.MultiplyVector(Vector3.back).normalized;
				Vector3 normalized = widgetToPanel.MultiplyVector(Vector3.right).normalized;
				this.mRtpTan = new Vector4(normalized.x, normalized.y, normalized.z, -1f);
				return;
			}
		}
		else
		{
			this.mRtpVerts.Clear();
		}
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x00030F58 File Offset: 0x0002F158
	public void WriteToBuffers(List<Vector3> v, List<Vector2> u, List<Color> c, List<Vector3> n, List<Vector4> t, List<Vector4> u2)
	{
		if (this.mRtpVerts != null && this.mRtpVerts.Count > 0)
		{
			if (n == null)
			{
				int i = 0;
				int count = this.mRtpVerts.Count;
				while (i < count)
				{
					v.Add(this.mRtpVerts[i]);
					u.Add(this.uvs[i]);
					c.Add(this.cols[i]);
					i++;
				}
			}
			else
			{
				int j = 0;
				int count2 = this.mRtpVerts.Count;
				while (j < count2)
				{
					v.Add(this.mRtpVerts[j]);
					u.Add(this.uvs[j]);
					c.Add(this.cols[j]);
					n.Add(this.mRtpNormal);
					t.Add(this.mRtpTan);
					j++;
				}
			}
			if (u2 != null)
			{
				Vector4 zero = Vector4.zero;
				int k = 0;
				int count3 = this.verts.Count;
				while (k < count3)
				{
					zero.x = this.verts[k].x;
					zero.y = this.verts[k].y;
					u2.Add(zero);
					k++;
				}
			}
			if (this.onCustomWrite != null)
			{
				this.onCustomWrite(v, u, c, n, t, u2);
			}
		}
	}

	// Token: 0x04000558 RID: 1368
	public List<Vector3> verts = new List<Vector3>();

	// Token: 0x04000559 RID: 1369
	public List<Vector2> uvs = new List<Vector2>();

	// Token: 0x0400055A RID: 1370
	public List<Color> cols = new List<Color>();

	// Token: 0x0400055B RID: 1371
	public UIGeometry.OnCustomWrite onCustomWrite;

	// Token: 0x0400055C RID: 1372
	private List<Vector3> mRtpVerts = new List<Vector3>();

	// Token: 0x0400055D RID: 1373
	private Vector3 mRtpNormal;

	// Token: 0x0400055E RID: 1374
	private Vector4 mRtpTan;

	// Token: 0x0200060A RID: 1546
	// (Invoke) Token: 0x060025C0 RID: 9664
	public delegate void OnCustomWrite(List<Vector3> v, List<Vector2> u, List<Color> c, List<Vector3> n, List<Vector4> t, List<Vector4> u2);
}
