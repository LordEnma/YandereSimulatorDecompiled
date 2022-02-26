using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000081 RID: 129
public class UIGeometry
{
	// Token: 0x1700008B RID: 139
	// (get) Token: 0x060004CD RID: 1229 RVA: 0x00030B38 File Offset: 0x0002ED38
	public bool hasVertices
	{
		get
		{
			return this.verts.Count > 0;
		}
	}

	// Token: 0x1700008C RID: 140
	// (get) Token: 0x060004CE RID: 1230 RVA: 0x00030B48 File Offset: 0x0002ED48
	public bool hasTransformed
	{
		get
		{
			return this.mRtpVerts != null && this.mRtpVerts.Count > 0 && this.mRtpVerts.Count == this.verts.Count;
		}
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x00030B7A File Offset: 0x0002ED7A
	public void Clear()
	{
		this.verts.Clear();
		this.uvs.Clear();
		this.cols.Clear();
		this.mRtpVerts.Clear();
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x00030BA8 File Offset: 0x0002EDA8
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

	// Token: 0x060004D1 RID: 1233 RVA: 0x00030C68 File Offset: 0x0002EE68
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

	// Token: 0x0400054D RID: 1357
	public List<Vector3> verts = new List<Vector3>();

	// Token: 0x0400054E RID: 1358
	public List<Vector2> uvs = new List<Vector2>();

	// Token: 0x0400054F RID: 1359
	public List<Color> cols = new List<Color>();

	// Token: 0x04000550 RID: 1360
	public UIGeometry.OnCustomWrite onCustomWrite;

	// Token: 0x04000551 RID: 1361
	private List<Vector3> mRtpVerts = new List<Vector3>();

	// Token: 0x04000552 RID: 1362
	private Vector3 mRtpNormal;

	// Token: 0x04000553 RID: 1363
	private Vector4 mRtpTan;

	// Token: 0x020005FE RID: 1534
	// (Invoke) Token: 0x06002579 RID: 9593
	public delegate void OnCustomWrite(List<Vector3> v, List<Vector2> u, List<Color> c, List<Vector3> n, List<Vector4> t, List<Vector4> u2);
}
