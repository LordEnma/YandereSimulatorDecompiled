using System.Collections.Generic;
using UnityEngine;

public class UIGeometry
{
	public delegate void OnCustomWrite(List<Vector3> v, List<Vector2> u, List<Color> c, List<Vector3> n, List<Vector4> t, List<Vector4> u2);

	public List<Vector3> verts = new List<Vector3>();

	public List<Vector2> uvs = new List<Vector2>();

	public List<Color> cols = new List<Color>();

	public OnCustomWrite onCustomWrite;

	private List<Vector3> mRtpVerts = new List<Vector3>();

	private Vector3 mRtpNormal;

	private Vector4 mRtpTan;

	public bool hasVertices => verts.Count > 0;

	public bool hasTransformed
	{
		get
		{
			if (mRtpVerts != null && mRtpVerts.Count > 0)
			{
				return mRtpVerts.Count == verts.Count;
			}
			return false;
		}
	}

	public void Clear()
	{
		verts.Clear();
		uvs.Clear();
		cols.Clear();
		mRtpVerts.Clear();
	}

	public void ApplyTransform(Matrix4x4 widgetToPanel, bool generateNormals = true)
	{
		if (verts.Count > 0)
		{
			mRtpVerts.Clear();
			int i = 0;
			for (int count = verts.Count; i < count; i++)
			{
				mRtpVerts.Add(widgetToPanel.MultiplyPoint3x4(verts[i]));
			}
			if (generateNormals)
			{
				mRtpNormal = widgetToPanel.MultiplyVector(Vector3.back).normalized;
				Vector3 normalized = widgetToPanel.MultiplyVector(Vector3.right).normalized;
				mRtpTan = new Vector4(normalized.x, normalized.y, normalized.z, -1f);
			}
		}
		else
		{
			mRtpVerts.Clear();
		}
	}

	public void WriteToBuffers(List<Vector3> v, List<Vector2> u, List<Color> c, List<Vector3> n, List<Vector4> t, List<Vector4> u2)
	{
		if (mRtpVerts == null || mRtpVerts.Count <= 0)
		{
			return;
		}
		if (n == null)
		{
			int i = 0;
			for (int count = mRtpVerts.Count; i < count; i++)
			{
				v.Add(mRtpVerts[i]);
				u.Add(uvs[i]);
				c.Add(cols[i]);
			}
		}
		else
		{
			int j = 0;
			for (int count2 = mRtpVerts.Count; j < count2; j++)
			{
				v.Add(mRtpVerts[j]);
				u.Add(uvs[j]);
				c.Add(cols[j]);
				n.Add(mRtpNormal);
				t.Add(mRtpTan);
			}
		}
		if (u2 != null)
		{
			Vector4 zero = Vector4.zero;
			int k = 0;
			for (int count3 = verts.Count; k < count3; k++)
			{
				zero.x = verts[k].x;
				zero.y = verts[k].y;
				u2.Add(zero);
			}
		}
		if (onCustomWrite != null)
		{
			onCustomWrite(v, u, c, n, t, u2);
		}
	}
}
