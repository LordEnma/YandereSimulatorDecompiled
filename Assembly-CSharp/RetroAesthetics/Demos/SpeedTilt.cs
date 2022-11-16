// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.Demos.SpeedTilt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace RetroAesthetics.Demos
{
  public class SpeedTilt : MonoBehaviour
  {
    public float minimumLocalPositionY = 1f;
    public float minimumLocalRotationX;
    public float maximumFOV = 80f;
    public float minSpeed = 0.5f;
    public float maxSpeed = 1f;
    private float _maxPositionY;
    private float _maxRotationX;
    private Vector3 _lastPosition;
    private float _distance;
    private Vector3 _localPosition;
    private Vector2 _localRotationYZ;
    private Camera _camera;
    private float _minFOV;

    private void Start()
    {
      this._maxPositionY = this.transform.localPosition.y;
      this._lastPosition = this.transform.position;
      this._localPosition = this.transform.localPosition;
      Quaternion localRotation = this.transform.localRotation;
      double y = (double) localRotation.eulerAngles.y;
      localRotation = this.transform.localRotation;
      double z = (double) localRotation.eulerAngles.z;
      this._localRotationYZ = new Vector2((float) y, (float) z);
      this._maxRotationX = this.transform.localRotation.eulerAngles.x;
      this._camera = this.gameObject.GetComponentInChildren<Camera>();
      if ((Object) this._camera == (Object) null)
        this.enabled = false;
      else
        this._minFOV = this._camera.fieldOfView;
    }

    private void FixedUpdate()
    {
      Vector3 vector3 = this._lastPosition - this.transform.position;
      if ((double) Mathf.Abs(vector3.y) < (double) Mathf.Max(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y)))
      {
        this._distance = vector3.magnitude;
        if ((double) this._distance > (double) this.minSpeed && (double) this._distance < (double) this.maxSpeed)
        {
          float t = Mathf.Clamp01((float) (((double) this._distance - (double) this.minSpeed) / ((double) this.maxSpeed - (double) this.minSpeed)));
          this._localPosition.y = Mathf.SmoothStep(this._maxPositionY, this.minimumLocalPositionY, t);
          this.transform.localPosition = this._localPosition;
          this.transform.localRotation = Quaternion.Euler(Mathf.SmoothStep(this._maxRotationX, this.minimumLocalRotationX, t), this._localRotationYZ.x, this._localRotationYZ.y);
          this._camera.fieldOfView = Mathf.SmoothStep(this._minFOV, this.maximumFOV, t);
        }
      }
      this._lastPosition = this.transform.position;
    }
  }
}
