// Decompiled with JetBrains decompiler
// Type: UIDragResize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag-Resize Widget")]
public class UIDragResize : MonoBehaviour
{
  public UIWidget target;
  public UIWidget.Pivot pivot = UIWidget.Pivot.BottomRight;
  public int minWidth = 100;
  public int minHeight = 100;
  public int maxWidth = 100000;
  public int maxHeight = 100000;
  public bool updateAnchors;
  private Plane mPlane;
  private Vector3 mRayPos;
  private Vector3 mLocalPos;
  private int mWidth;
  private int mHeight;
  private bool mDragging;

  private void OnDragStart()
  {
    if (!((Object) this.target != (Object) null))
      return;
    Vector3[] worldCorners = this.target.worldCorners;
    this.mPlane = new Plane(worldCorners[0], worldCorners[1], worldCorners[3]);
    Ray currentRay = UICamera.currentRay;
    float enter;
    if (!this.mPlane.Raycast(currentRay, out enter))
      return;
    this.mRayPos = currentRay.GetPoint(enter);
    this.mLocalPos = this.target.cachedTransform.localPosition;
    this.mWidth = this.target.width;
    this.mHeight = this.target.height;
    this.mDragging = true;
  }

  private void OnDrag(Vector2 delta)
  {
    if (!this.mDragging || !((Object) this.target != (Object) null))
      return;
    Ray currentRay = UICamera.currentRay;
    float enter;
    if (!this.mPlane.Raycast(currentRay, out enter))
      return;
    Transform cachedTransform = this.target.cachedTransform;
    cachedTransform.localPosition = this.mLocalPos;
    this.target.width = this.mWidth;
    this.target.height = this.mHeight;
    Vector3 vector3_1 = currentRay.GetPoint(enter) - this.mRayPos;
    cachedTransform.position += vector3_1;
    Vector3 vector3_2 = Quaternion.Inverse(cachedTransform.localRotation) * (cachedTransform.localPosition - this.mLocalPos);
    cachedTransform.localPosition = this.mLocalPos;
    NGUIMath.ResizeWidget(this.target, this.pivot, vector3_2.x, vector3_2.y, this.minWidth, this.minHeight, this.maxWidth, this.maxHeight);
    if (!this.updateAnchors)
      return;
    this.target.BroadcastMessage("UpdateAnchors");
  }

  private void OnDragEnd() => this.mDragging = false;
}
