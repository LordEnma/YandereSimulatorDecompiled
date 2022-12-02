using System.Collections.Generic;
using UnityEngine;

public class WeaponTrail : MonoBehaviour
{
	public class Point
	{
		public float timeCreated;

		public Vector3 basePosition;

		public Vector3 tipPosition;

		public bool lineBreak;
	}

	[SerializeField]
	private bool _emit = true;

	[SerializeField]
	private float _emitTime;

	[SerializeField]
	private Material _material;

	[SerializeField]
	private float _lifeTime = 1f;

	[SerializeField]
	private Color[] _colors;

	[SerializeField]
	private float[] _sizes;

	[SerializeField]
	private float _minVertexDistance = 0.1f;

	[SerializeField]
	private float _maxVertexDistance = 10f;

	[SerializeField]
	private float _maxAngle = 3f;

	[SerializeField]
	private bool _autoDestruct;

	[SerializeField]
	private Transform _base;

	[SerializeField]
	private Transform _tip;

	private List<Point> _points = new List<Point>();

	private GameObject _o;

	private Mesh _trailMesh;

	private Vector3 _lastPosition;

	private Vector3 _lastCameraPosition1;

	private Vector3 _lastCameraPosition2;

	private bool _lastFrameEmit = true;

	public bool Emit
	{
		set
		{
			_emit = value;
		}
	}

	public void Start()
	{
		_lastPosition = base.transform.position;
		_o = new GameObject("Trail");
		_o.transform.parent = null;
		_o.transform.position = Vector3.zero;
		_o.transform.rotation = Quaternion.identity;
		_o.transform.localScale = Vector3.one;
		_o.AddComponent<MeshFilter>();
		_o.AddComponent<MeshRenderer>();
		_o.GetComponent<Renderer>().material = _material;
		_trailMesh = new Mesh();
		_trailMesh.name = base.name + "TrailMesh";
		_o.GetComponent<MeshFilter>().mesh = _trailMesh;
	}

	private void OnDisable()
	{
		Object.Destroy(_o);
	}

	private void Update()
	{
		if (_emit && _emitTime != 0f)
		{
			_emitTime -= Time.deltaTime;
			if (_emitTime == 0f)
			{
				_emitTime = -1f;
			}
			if (_emitTime < 0f)
			{
				_emit = false;
			}
		}
		if (!_emit && _points.Count == 0 && _autoDestruct)
		{
			Object.Destroy(_o);
			Object.Destroy(base.gameObject);
		}
		if (!Camera.main)
		{
			return;
		}
		float magnitude = (_lastPosition - base.transform.position).magnitude;
		if (_emit)
		{
			if (magnitude > _minVertexDistance)
			{
				bool flag = false;
				if (_points.Count < 3)
				{
					flag = true;
				}
				else
				{
					Vector3 from = _points[_points.Count - 2].tipPosition - _points[_points.Count - 3].tipPosition;
					Vector3 to = _points[_points.Count - 1].tipPosition - _points[_points.Count - 2].tipPosition;
					if (Vector3.Angle(from, to) > _maxAngle || magnitude > _maxVertexDistance)
					{
						flag = true;
					}
				}
				if (flag)
				{
					Point point = new Point();
					point.basePosition = _base.position;
					point.tipPosition = _tip.position;
					point.timeCreated = Time.time;
					_points.Add(point);
					_lastPosition = base.transform.position;
				}
				else
				{
					_points[_points.Count - 1].basePosition = _base.position;
					_points[_points.Count - 1].tipPosition = _tip.position;
				}
			}
			else if (_points.Count > 0)
			{
				_points[_points.Count - 1].basePosition = _base.position;
				_points[_points.Count - 1].tipPosition = _tip.position;
			}
		}
		if (!_emit && _lastFrameEmit && _points.Count > 0)
		{
			_points[_points.Count - 1].lineBreak = true;
		}
		_lastFrameEmit = _emit;
		List<Point> list = new List<Point>();
		foreach (Point point3 in _points)
		{
			if (Time.time - point3.timeCreated > _lifeTime)
			{
				list.Add(point3);
			}
		}
		foreach (Point item in list)
		{
			_points.Remove(item);
		}
		List<Point> points = _points;
		if (points.Count > 1)
		{
			Vector3[] array = new Vector3[points.Count * 2];
			Vector2[] array2 = new Vector2[points.Count * 2];
			int[] array3 = new int[(points.Count - 1) * 6];
			Color[] array4 = new Color[points.Count * 2];
			for (int i = 0; i < points.Count; i++)
			{
				Point point2 = points[i];
				float num = (Time.time - point2.timeCreated) / _lifeTime;
				Color color = Color.Lerp(Color.white, Color.clear, num);
				if (_colors != null && _colors.Length != 0)
				{
					float num2 = num * (float)(_colors.Length - 1);
					float num3 = Mathf.Floor(num2);
					float num4 = Mathf.Clamp(Mathf.Ceil(num2), 1f, (float)_colors.Length - 1f);
					float t = Mathf.InverseLerp(num3, num4, num2);
					if (num3 >= (float)_colors.Length)
					{
						num3 = (float)_colors.Length - 1f;
					}
					if (num3 < 0f)
					{
						num3 = 0f;
					}
					if (num4 >= (float)_colors.Length)
					{
						num4 = (float)_colors.Length - 1f;
					}
					if (num4 < 0f)
					{
						num4 = 0f;
					}
					color = Color.Lerp(_colors[(int)num3], _colors[(int)num4], t);
				}
				float num5 = 0f;
				if (_sizes != null && _sizes.Length != 0)
				{
					float num6 = num * (float)(_sizes.Length - 1);
					float num7 = Mathf.Floor(num6);
					float num8 = Mathf.Clamp(Mathf.Ceil(num6), 1f, (float)_sizes.Length - 1f);
					float t2 = Mathf.InverseLerp(num7, num8, num6);
					if (num7 >= (float)_sizes.Length)
					{
						num7 = (float)_sizes.Length - 1f;
					}
					if (num7 < 0f)
					{
						num7 = 0f;
					}
					if (num8 >= (float)_sizes.Length)
					{
						num8 = (float)_sizes.Length - 1f;
					}
					if (num8 < 0f)
					{
						num8 = 0f;
					}
					num5 = Mathf.Lerp(_sizes[(int)num7], _sizes[(int)num8], t2);
				}
				Vector3 vector = point2.tipPosition - point2.basePosition;
				array[i * 2] = point2.basePosition - vector * (num5 * 0.5f);
				array[i * 2 + 1] = point2.tipPosition + vector * (num5 * 0.5f);
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
			_trailMesh.Clear();
			_trailMesh.vertices = array;
			_trailMesh.colors = array4;
			_trailMesh.uv = array2;
			_trailMesh.triangles = array3;
		}
		else
		{
			_trailMesh.Clear();
		}
	}
}
