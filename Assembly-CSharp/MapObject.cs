// Decompiled with JetBrains decompiler
// Type: MapObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
  private MiniMapEntity linkedMiniMapEntity;
  private MiniMapController mmc;
  private GameObject owner;
  private Camera mapCamera;
  private Image spr;
  private GameObject panelGO;
  private Vector3 viewPortPos;
  private RectTransform rt;
  private Vector3[] cornerss;
  private RectTransform sprRect;
  private Vector2 screenPos;
  private Transform miniMapTarget;

  private void FixedUpdate()
  {
    if ((Object) this.owner == (Object) null)
      Object.Destroy((Object) this.gameObject);
    else
      this.SetPositionAndRotation();
  }

  public void SetMiniMapEntityValues(
    MiniMapController controller,
    MiniMapEntity mme,
    GameObject attachedGO,
    Camera renderCamera,
    GameObject parentPanelGO)
  {
    this.linkedMiniMapEntity = mme;
    this.owner = attachedGO;
    this.mapCamera = renderCamera;
    this.panelGO = parentPanelGO;
    this.spr = this.gameObject.GetComponent<Image>();
    this.spr.sprite = mme.icon;
    this.sprRect = this.spr.gameObject.GetComponent<RectTransform>();
    this.sprRect.sizeDelta = mme.size;
    this.rt = this.panelGO.GetComponent<RectTransform>();
    this.mmc = controller;
    this.miniMapTarget = this.mmc.target;
    this.SetPositionAndRotation();
  }

  private void SetPositionAndRotation()
  {
    this.transform.SetParent(this.panelGO.transform, false);
    this.SetPosition();
    this.SetRotation();
  }

  private void SetPosition()
  {
    this.cornerss = new Vector3[4];
    this.rt.GetWorldCorners(this.cornerss);
    this.screenPos = RectTransformUtility.WorldToScreenPoint(this.mapCamera, this.owner.transform.position);
    if (this.linkedMiniMapEntity.clampInBorder && (double) Mathf.Abs(Vector3.Distance(this.owner.transform.position, this.mmc.target.transform.position)) < (double) this.linkedMiniMapEntity.clampDist)
      this.ClampIconColliderWise();
    else
      this.sprRect.anchoredPosition = this.screenPos - this.rt.sizeDelta / 2f;
  }

  private void ClampIconColliderWise()
  {
    this.sprRect.anchoredPosition = this.screenPos - this.rt.sizeDelta / 2f;
    RaycastHit2D[] raycastHit2DArray = Physics2D.RaycastAll((Vector2) this.sprRect.position, (Vector2) (this.rt.position - this.sprRect.position));
    if (raycastHit2DArray.Length == 0)
      return;
    for (int index = 0; index < raycastHit2DArray.Length; ++index)
    {
      if (raycastHit2DArray[index].transform.name == this.mmc.shapeColliderGO.name)
      {
        this.sprRect.position = (Vector3) raycastHit2DArray[index].point;
        break;
      }
    }
  }

  private void SetRotation()
  {
    if (this.linkedMiniMapEntity.rotateWithObject)
    {
      if ((double) Mathf.Abs(this.linkedMiniMapEntity.upAxis.y) == 1.0)
      {
        if (this.mmc.rotateWithTarget)
          this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, this.linkedMiniMapEntity.upAxis.y * (this.miniMapTarget.transform.localEulerAngles.y - this.mmc.rotationOfCam.z - this.owner.transform.localEulerAngles.y) + this.linkedMiniMapEntity.rotation);
        else
          this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, -this.linkedMiniMapEntity.upAxis.y * this.owner.transform.localEulerAngles.y + this.linkedMiniMapEntity.rotation);
      }
      else if ((double) Mathf.Abs(this.linkedMiniMapEntity.upAxis.z) == 1.0)
      {
        if (this.mmc.rotateWithTarget)
          this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, this.linkedMiniMapEntity.upAxis.z * (this.miniMapTarget.transform.localEulerAngles.z - this.mmc.rotationOfCam.z - this.owner.transform.localEulerAngles.z) + this.linkedMiniMapEntity.rotation);
        else
          this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, -this.linkedMiniMapEntity.upAxis.z * this.owner.transform.localEulerAngles.z + this.linkedMiniMapEntity.rotation);
      }
      else
      {
        if ((double) Mathf.Abs(this.linkedMiniMapEntity.upAxis.x) != 1.0)
          return;
        if (this.mmc.rotateWithTarget)
          this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, this.linkedMiniMapEntity.upAxis.x * (this.miniMapTarget.transform.localEulerAngles.x - this.mmc.rotationOfCam.z - this.owner.transform.localEulerAngles.x) + this.linkedMiniMapEntity.rotation);
        else
          this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, -this.linkedMiniMapEntity.upAxis.x * this.owner.transform.localEulerAngles.x + this.linkedMiniMapEntity.rotation);
      }
    }
    else if ((double) Mathf.Abs(this.linkedMiniMapEntity.upAxis.y) == 1.0)
      this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, this.sprRect.localEulerAngles.y + this.linkedMiniMapEntity.rotation);
    else if ((double) Mathf.Abs(this.linkedMiniMapEntity.upAxis.z) == 1.0)
    {
      this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, this.sprRect.localEulerAngles.z + this.linkedMiniMapEntity.rotation);
    }
    else
    {
      if ((double) Mathf.Abs(this.linkedMiniMapEntity.upAxis.x) != 1.0)
        return;
      this.sprRect.localEulerAngles = new Vector3(0.0f, 0.0f, this.sprRect.localEulerAngles.x + this.linkedMiniMapEntity.rotation);
    }
  }
}
