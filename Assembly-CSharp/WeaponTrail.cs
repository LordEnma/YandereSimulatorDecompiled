// Decompiled with JetBrains decompiler
// Type: WeaponTrail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class WeaponTrail : MonoBehaviour
{
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
  private List<WeaponTrail.Point> _points = new List<WeaponTrail.Point>();
  private GameObject _o;
  private Mesh _trailMesh;
  private Vector3 _lastPosition;
  private Vector3 _lastCameraPosition1;
  private Vector3 _lastCameraPosition2;
  private bool _lastFrameEmit = true;

  public bool Emit
  {
    set => this._emit = value;
  }

  public void Start()
  {
    this._lastPosition = this.transform.position;
    this._o = new GameObject("Trail");
    this._o.transform.parent = (Transform) null;
    this._o.transform.position = Vector3.zero;
    this._o.transform.rotation = Quaternion.identity;
    this._o.transform.localScale = Vector3.one;
    this._o.AddComponent<MeshFilter>();
    this._o.AddComponent<MeshRenderer>();
    this._o.GetComponent<Renderer>().material = this._material;
    this._trailMesh = new Mesh();
    this._trailMesh.name = this.name + "TrailMesh";
    this._o.GetComponent<MeshFilter>().mesh = this._trailMesh;
  }

  private void OnDisable() => Object.Destroy((Object) this._o);

  private void Update()
  {
    if (this._emit && (double) this._emitTime != 0.0)
    {
      this._emitTime -= Time.deltaTime;
      if ((double) this._emitTime == 0.0)
        this._emitTime = -1f;
      if ((double) this._emitTime < 0.0)
        this._emit = false;
    }
    if (!this._emit && this._points.Count == 0 && this._autoDestruct)
    {
      Object.Destroy((Object) this._o);
      Object.Destroy((Object) this.gameObject);
    }
    if (!(bool) (Object) Camera.main)
      return;
    float magnitude = (this._lastPosition - this.transform.position).magnitude;
    if (this._emit)
    {
      if ((double) magnitude > (double) this._minVertexDistance)
      {
        bool flag = false;
        if (this._points.Count < 3)
          flag = true;
        else if ((double) Vector3.Angle(this._points[this._points.Count - 2].tipPosition - this._points[this._points.Count - 3].tipPosition, this._points[this._points.Count - 1].tipPosition - this._points[this._points.Count - 2].tipPosition) > (double) this._maxAngle || (double) magnitude > (double) this._maxVertexDistance)
          flag = true;
        if (flag)
        {
          this._points.Add(new WeaponTrail.Point()
          {
            basePosition = this._base.position,
            tipPosition = this._tip.position,
            timeCreated = Time.time
          });
          this._lastPosition = this.transform.position;
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
      this._points[this._points.Count - 1].lineBreak = true;
    this._lastFrameEmit = this._emit;
    List<WeaponTrail.Point> pointList = new List<WeaponTrail.Point>();
    foreach (WeaponTrail.Point point in this._points)
    {
      if ((double) Time.time - (double) point.timeCreated > (double) this._lifeTime)
        pointList.Add(point);
    }
    foreach (WeaponTrail.Point point in pointList)
      this._points.Remove(point);
    List<WeaponTrail.Point> points = this._points;
    if (points.Count > 1)
    {
      Vector3[] vector3Array = new Vector3[points.Count * 2];
      Vector2[] vector2Array = new Vector2[points.Count * 2];
      int[] numArray = new int[(points.Count - 1) * 6];
      Color[] colorArray = new Color[points.Count * 2];
      for (int index = 0; index < points.Count; ++index)
      {
        WeaponTrail.Point point = points[index];
        float t1 = (Time.time - point.timeCreated) / this._lifeTime;
        Color color = Color.Lerp(Color.white, Color.clear, t1);
        if (this._colors != null && this._colors.Length != 0)
        {
          float f = t1 * (float) (this._colors.Length - 1);
          float a = Mathf.Floor(f);
          float b = Mathf.Clamp(Mathf.Ceil(f), 1f, (float) this._colors.Length - 1f);
          float t2 = Mathf.InverseLerp(a, b, f);
          if ((double) a >= (double) this._colors.Length)
            a = (float) this._colors.Length - 1f;
          if ((double) a < 0.0)
            a = 0.0f;
          if ((double) b >= (double) this._colors.Length)
            b = (float) this._colors.Length - 1f;
          if ((double) b < 0.0)
            b = 0.0f;
          color = Color.Lerp(this._colors[(int) a], this._colors[(int) b], t2);
        }
        float num = 0.0f;
        if (this._sizes != null && this._sizes.Length != 0)
        {
          float f = t1 * (float) (this._sizes.Length - 1);
          float a = Mathf.Floor(f);
          float b = Mathf.Clamp(Mathf.Ceil(f), 1f, (float) this._sizes.Length - 1f);
          float t3 = Mathf.InverseLerp(a, b, f);
          if ((double) a >= (double) this._sizes.Length)
            a = (float) this._sizes.Length - 1f;
          if ((double) a < 0.0)
            a = 0.0f;
          if ((double) b >= (double) this._sizes.Length)
            b = (float) this._sizes.Length - 1f;
          if ((double) b < 0.0)
            b = 0.0f;
          num = Mathf.Lerp(this._sizes[(int) a], this._sizes[(int) b], t3);
        }
        Vector3 vector3 = point.tipPosition - point.basePosition;
        vector3Array[index * 2] = point.basePosition - vector3 * (num * 0.5f);
        vector3Array[index * 2 + 1] = point.tipPosition + vector3 * (num * 0.5f);
        colorArray[index * 2] = colorArray[index * 2 + 1] = color;
        float x = (float) index / (float) points.Count;
        vector2Array[index * 2] = new Vector2(x, 0.0f);
        vector2Array[index * 2 + 1] = new Vector2(x, 1f);
        if (index > 0)
        {
          numArray[(index - 1) * 6] = index * 2 - 2;
          numArray[(index - 1) * 6 + 1] = index * 2 - 1;
          numArray[(index - 1) * 6 + 2] = index * 2;
          numArray[(index - 1) * 6 + 3] = index * 2 + 1;
          numArray[(index - 1) * 6 + 4] = index * 2;
          numArray[(index - 1) * 6 + 5] = index * 2 - 1;
        }
      }
      this._trailMesh.Clear();
      this._trailMesh.vertices = vector3Array;
      this._trailMesh.colors = colorArray;
      this._trailMesh.uv = vector2Array;
      this._trailMesh.triangles = numArray;
    }
    else
      this._trailMesh.Clear();
  }

  public class Point
  {
    public float timeCreated;
    public Vector3 basePosition;
    public Vector3 tipPosition;
    public bool lineBreak;
  }
}
