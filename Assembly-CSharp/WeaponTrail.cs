using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004C7 RID: 1223
public class WeaponTrail : MonoBehaviour
{
	// Token: 0x170004CA RID: 1226
	// (set) Token: 0x06002008 RID: 8200 RVA: 0x001C73E1 File Offset: 0x001C55E1
	public bool Emit
	{
		set
		{
			this._emit = value;
		}
	}

	// Token: 0x06002009 RID: 8201 RVA: 0x001C73EC File Offset: 0x001C55EC
	public void Start()
	{
		this._lastPosition = base.transform.position;
		this._o = new GameObject("Trail");
		this._o.transform.parent = null;
		this._o.transform.position = Vector3.zero;
		this._o.transform.rotation = Quaternion.identity;
		this._o.transform.localScale = Vector3.one;
		this._o.AddComponent<MeshFilter>();
		this._o.AddComponent<MeshRenderer>();
		this._o.GetComponent<Renderer>().material = this._material;
		this._trailMesh = new Mesh();
		this._trailMesh.name = base.name + "TrailMesh";
		this._o.GetComponent<MeshFilter>().mesh = this._trailMesh;
	}

	// Token: 0x0600200A RID: 8202 RVA: 0x001C74D4 File Offset: 0x001C56D4
	private void OnDisable()
	{
		UnityEngine.Object.Destroy(this._o);
	}

	// Token: 0x0600200B RID: 8203 RVA: 0x001C74E4 File Offset: 0x001C56E4
	private void Update()
	{
		if (this._emit && this._emitTime != 0f)
		{
			this._emitTime -= Time.deltaTime;
			if (this._emitTime == 0f)
			{
				this._emitTime = -1f;
			}
			if (this._emitTime < 0f)
			{
				this._emit = false;
			}
		}
		if (!this._emit && this._points.Count == 0 && this._autoDestruct)
		{
			UnityEngine.Object.Destroy(this._o);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (!Camera.main)
		{
			return;
		}
		float magnitude = (this._lastPosition - base.transform.position).magnitude;
		if (this._emit)
		{
			if (magnitude > this._minVertexDistance)
			{
				bool flag = false;
				if (this._points.Count < 3)
				{
					flag = true;
				}
				else
				{
					Vector3 from = this._points[this._points.Count - 2].tipPosition - this._points[this._points.Count - 3].tipPosition;
					Vector3 to = this._points[this._points.Count - 1].tipPosition - this._points[this._points.Count - 2].tipPosition;
					if (Vector3.Angle(from, to) > this._maxAngle || magnitude > this._maxVertexDistance)
					{
						flag = true;
					}
				}
				if (flag)
				{
					WeaponTrail.Point point = new WeaponTrail.Point();
					point.basePosition = this._base.position;
					point.tipPosition = this._tip.position;
					point.timeCreated = Time.time;
					this._points.Add(point);
					this._lastPosition = base.transform.position;
				}
				else
				{
					this._points[this._points.Count - 1].basePosition = this._base.position;
					this._points[this._points.Count - 1].tipPosition = this._tip.position;
				}
			}
			else if (this._points.Count > 0)
			{
				this._points[this._points.Count - 1].basePosition = this._base.position;
				this._points[this._points.Count - 1].tipPosition = this._tip.position;
			}
		}
		if (!this._emit && this._lastFrameEmit && this._points.Count > 0)
		{
			this._points[this._points.Count - 1].lineBreak = true;
		}
		this._lastFrameEmit = this._emit;
		List<WeaponTrail.Point> list = new List<WeaponTrail.Point>();
		foreach (WeaponTrail.Point point2 in this._points)
		{
			if (Time.time - point2.timeCreated > this._lifeTime)
			{
				list.Add(point2);
			}
		}
		foreach (WeaponTrail.Point item in list)
		{
			this._points.Remove(item);
		}
		List<WeaponTrail.Point> points = this._points;
		if (points.Count > 1)
		{
			Vector3[] array = new Vector3[points.Count * 2];
			Vector2[] array2 = new Vector2[points.Count * 2];
			int[] array3 = new int[(points.Count - 1) * 6];
			Color[] array4 = new Color[points.Count * 2];
			for (int i = 0; i < points.Count; i++)
			{
				WeaponTrail.Point point3 = points[i];
				float num = (Time.time - point3.timeCreated) / this._lifeTime;
				Color color = Color.Lerp(Color.white, Color.clear, num);
				if (this._colors != null && this._colors.Length != 0)
				{
					float num2 = num * (float)(this._colors.Length - 1);
					float num3 = Mathf.Floor(num2);
					float num4 = Mathf.Clamp(Mathf.Ceil(num2), 1f, (float)this._colors.Length - 1f);
					float t = Mathf.InverseLerp(num3, num4, num2);
					if (num3 >= (float)this._colors.Length)
					{
						num3 = (float)this._colors.Length - 1f;
					}
					if (num3 < 0f)
					{
						num3 = 0f;
					}
					if (num4 >= (float)this._colors.Length)
					{
						num4 = (float)this._colors.Length - 1f;
					}
					if (num4 < 0f)
					{
						num4 = 0f;
					}
					color = Color.Lerp(this._colors[(int)num3], this._colors[(int)num4], t);
				}
				float num5 = 0f;
				if (this._sizes != null && this._sizes.Length != 0)
				{
					float num6 = num * (float)(this._sizes.Length - 1);
					float num7 = Mathf.Floor(num6);
					float num8 = Mathf.Clamp(Mathf.Ceil(num6), 1f, (float)this._sizes.Length - 1f);
					float t2 = Mathf.InverseLerp(num7, num8, num6);
					if (num7 >= (float)this._sizes.Length)
					{
						num7 = (float)this._sizes.Length - 1f;
					}
					if (num7 < 0f)
					{
						num7 = 0f;
					}
					if (num8 >= (float)this._sizes.Length)
					{
						num8 = (float)this._sizes.Length - 1f;
					}
					if (num8 < 0f)
					{
						num8 = 0f;
					}
					num5 = Mathf.Lerp(this._sizes[(int)num7], this._sizes[(int)num8], t2);
				}
				Vector3 a = point3.tipPosition - point3.basePosition;
				array[i * 2] = point3.basePosition - a * (num5 * 0.5f);
				array[i * 2 + 1] = point3.tipPosition + a * (num5 * 0.5f);
				array4[i * 2] = (array4[i * 2 + 1] = color);
				float x = (float)i / (float)points.Count;
				array2[i * 2] = new Vector2(x, 0f);
				array2[i * 2 + 1] = new Vector2(x, 1f);
				if (i > 0)
				{
					array3[(i - 1) * 6] = i * 2 - 2;
					array3[(i - 1) * 6 + 1] = i * 2 - 1;
					array3[(i - 1) * 6 + 2] = i * 2;
					array3[(i - 1) * 6 + 3] = i * 2 + 1;
					array3[(i - 1) * 6 + 4] = i * 2;
					array3[(i - 1) * 6 + 5] = i * 2 - 1;
				}
			}
			this._trailMesh.Clear();
			this._trailMesh.vertices = array;
			this._trailMesh.colors = array4;
			this._trailMesh.uv = array2;
			this._trailMesh.triangles = array3;
			return;
		}
		this._trailMesh.Clear();
	}

	// Token: 0x04004367 RID: 17255
	[SerializeField]
	private bool _emit = true;

	// Token: 0x04004368 RID: 17256
	[SerializeField]
	private float _emitTime;

	// Token: 0x04004369 RID: 17257
	[SerializeField]
	private Material _material;

	// Token: 0x0400436A RID: 17258
	[SerializeField]
	private float _lifeTime = 1f;

	// Token: 0x0400436B RID: 17259
	[SerializeField]
	private Color[] _colors;

	// Token: 0x0400436C RID: 17260
	[SerializeField]
	private float[] _sizes;

	// Token: 0x0400436D RID: 17261
	[SerializeField]
	private float _minVertexDistance = 0.1f;

	// Token: 0x0400436E RID: 17262
	[SerializeField]
	private float _maxVertexDistance = 10f;

	// Token: 0x0400436F RID: 17263
	[SerializeField]
	private float _maxAngle = 3f;

	// Token: 0x04004370 RID: 17264
	[SerializeField]
	private bool _autoDestruct;

	// Token: 0x04004371 RID: 17265
	[SerializeField]
	private Transform _base;

	// Token: 0x04004372 RID: 17266
	[SerializeField]
	private Transform _tip;

	// Token: 0x04004373 RID: 17267
	private List<WeaponTrail.Point> _points = new List<WeaponTrail.Point>();

	// Token: 0x04004374 RID: 17268
	private GameObject _o;

	// Token: 0x04004375 RID: 17269
	private Mesh _trailMesh;

	// Token: 0x04004376 RID: 17270
	private Vector3 _lastPosition;

	// Token: 0x04004377 RID: 17271
	private Vector3 _lastCameraPosition1;

	// Token: 0x04004378 RID: 17272
	private Vector3 _lastCameraPosition2;

	// Token: 0x04004379 RID: 17273
	private bool _lastFrameEmit = true;

	// Token: 0x02000677 RID: 1655
	public class Point
	{
		// Token: 0x04005062 RID: 20578
		public float timeCreated;

		// Token: 0x04005063 RID: 20579
		public Vector3 basePosition;

		// Token: 0x04005064 RID: 20580
		public Vector3 tipPosition;

		// Token: 0x04005065 RID: 20581
		public bool lineBreak;
	}
}
