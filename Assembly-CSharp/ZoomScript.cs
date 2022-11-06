// Decompiled with JetBrains decompiler
// Type: ZoomScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ZoomScript : MonoBehaviour
{
  public CardboardBoxScript CardboardBox;
  public RPG_Camera CameraScript;
  public YandereScript Yandere;
  public float TargetZoom;
  public float Zoom;
  public float ShakeStrength;
  public float midOffset = 0.25f;
  public float Slender;
  public float Height;
  public float Timer;
  public Vector3 Target;
  public bool OverShoulder;
  public bool MoveCamera;
  public GameObject TallHat;

  private void Update()
  {
    if (this.Yandere.FollowHips)
      this.transform.position = new Vector3(Mathf.MoveTowards(this.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime), this.transform.position.y, Mathf.MoveTowards(this.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime));
    this.Height = this.Yandere.Stance.Current != StanceType.Crawling ? (this.Yandere.Stance.Current != StanceType.Crouching ? 1f : 0.6f) : 0.2f;
    if (!this.Yandere.FollowHips)
    {
      if (this.Yandere.FlameDemonic)
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.MoveTowards(this.transform.localPosition.y, (float) ((double) this.Height + (double) this.Zoom + 0.40000000596046448), Time.deltaTime), this.transform.localPosition.z);
      else if (this.Yandere.Slender)
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.MoveTowards(this.transform.localPosition.y, this.Height + this.Zoom + this.Slender, Time.deltaTime), this.transform.localPosition.z);
      else if (this.Yandere.Stand.Stand.activeInHierarchy)
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.MoveTowards(this.transform.localPosition.y, (float) ((double) this.Height - (double) this.Zoom * 0.5 + (double) this.Slender * 0.5), Time.deltaTime), this.transform.localPosition.z);
      else
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, this.Height + this.Zoom, Time.deltaTime * 5f), this.transform.localPosition.z);
    }
    else if (!this.Yandere.SithLord)
      this.transform.position = new Vector3(this.transform.position.x, Mathf.MoveTowards(this.transform.position.y, this.Yandere.Hips.position.y + this.Zoom, Time.deltaTime), this.transform.position.z);
    else
      this.transform.position = new Vector3(this.transform.position.x, Mathf.MoveTowards(this.transform.position.y, this.Yandere.Hips.position.y, Time.deltaTime), this.transform.position.z);
    if (!this.Yandere.Aiming && this.Yandere.CanMove && !this.Yandere.PauseScreen.Show)
      this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
    this.Slender = this.Yandere.SithLord || this.Yandere.Riding ? Mathf.Lerp(this.Slender, 2.5f, Time.deltaTime) : (this.Yandere.Slender || this.Yandere.Stand.Stand.activeInHierarchy || this.Yandere.Blasting || this.Yandere.PK || this.Yandere.Shipgirl || this.TallHat.activeInHierarchy || this.Yandere.Man.activeInHierarchy || this.Yandere.Pod.activeInHierarchy || this.Yandere.LucyHelmet.activeInHierarchy || this.Yandere.Kagune[0].activeInHierarchy || this.Yandere.Demonic || this.Yandere.FloppyHat.activeInHierarchy ? Mathf.Lerp(this.Slender, 0.5f, Time.deltaTime) : Mathf.Lerp(this.Slender, 0.0f, Time.deltaTime));
    if ((double) this.TargetZoom < 0.0)
      this.TargetZoom = 0.0f;
    if (this.Yandere.Stance.Current == StanceType.Crawling)
    {
      if ((double) this.TargetZoom > 0.30000001192092896)
        this.TargetZoom = 0.3f;
    }
    else if ((double) this.TargetZoom > 0.40000000596046448)
      this.TargetZoom = 0.4f;
    if ((double) this.Zoom != (double) this.TargetZoom)
    {
      this.Zoom = Mathf.MoveTowards(this.Zoom, this.TargetZoom, Time.deltaTime);
      this.Yandere.CameraEffects.UpdateDOF((float) (2.0 - (double) this.Zoom * 3.75));
    }
    if (!this.Yandere.Possessed)
    {
      this.CameraScript.distance = (float) (2.0 - (double) this.Zoom * 3.3333299160003662) + this.Slender;
      this.CameraScript.distanceMax = (float) (2.0 - (double) this.Zoom * 3.3333299160003662) + this.Slender;
      this.CameraScript.distanceMin = (float) (2.0 - (double) this.Zoom * 3.3333299160003662) + this.Slender;
      if (this.Yandere.TornadoHair.activeInHierarchy || (Object) this.CardboardBox != (Object) null && (Object) this.CardboardBox.transform.parent == (Object) this.Yandere.Hips)
        this.CameraScript.distanceMax += 3f;
    }
    else
    {
      this.CameraScript.distance = 5f;
      this.CameraScript.distanceMax = 5f;
    }
    if (!this.Yandere.TimeSkipping)
    {
      this.Timer += Time.deltaTime;
      this.ShakeStrength = Mathf.Lerp(this.ShakeStrength, (float) (1.0 - (double) this.Yandere.Sanity * 0.0099999997764825821), Time.deltaTime);
      if ((double) this.Timer > 0.10000000149011612 + (double) this.Yandere.Sanity * 0.0099999997764825821)
      {
        this.Target.x = Random.Range(-this.ShakeStrength, this.ShakeStrength);
        this.Target.y = this.transform.localPosition.y;
        this.Target.z = Random.Range(-this.ShakeStrength, this.ShakeStrength);
        this.Timer = 0.0f;
      }
    }
    else
      this.Target = new Vector3(0.0f, this.transform.localPosition.y, 0.0f);
    if (this.Yandere.RoofPush)
      this.transform.position = new Vector3(Mathf.MoveTowards(this.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime * 10f), this.transform.position.y, Mathf.MoveTowards(this.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime * 10f));
    else
      this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, this.Target, (float) ((double) Time.deltaTime * (double) this.ShakeStrength * 0.10000000149011612));
  }

  public void LateUpdate()
  {
    this.transform.eulerAngles = Vector3.zero;
    if (this.OverShoulder)
    {
      Vector3 lhs = this.Yandere.MainCamera.transform.TransformDirection(Vector3.forward);
      this.transform.position = new Vector3(this.Yandere.transform.position.x + this.midOffset * Vector3.Dot(lhs, Vector3.forward), this.transform.position.y, this.Yandere.transform.position.z + this.midOffset * Vector3.Dot(lhs, -Vector3.right));
    }
    else if (this.Yandere.FollowHips)
      this.transform.position = new Vector3(Mathf.MoveTowards(this.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime), this.transform.position.y, Mathf.MoveTowards(this.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime));
    else
      this.transform.localPosition = new Vector3(0.0f, this.transform.localPosition.y, 0.0f);
  }
}
