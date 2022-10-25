// Decompiled with JetBrains decompiler
// Type: MiniMapComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MiniMapComponent : MonoBehaviour
{
  [Tooltip("Set the icon of this gameobject")]
  public UnityEngine.Sprite icon;
  [Tooltip("Set size of the icon")]
  public Vector2 size = new Vector2(20f, 20f);
  [Tooltip("Set true if the icon rotates with the gameobject")]
  public bool rotateWithObject;
  [Tooltip("Adjust the rotation axis according to your gameobject. Values of each axis can be either -1,0 or 1")]
  public Vector3 upAxis = new Vector3(0.0f, 1f, 0.0f);
  [Tooltip("Adjust initial rotation of the icon")]
  public float initialIconRotation;
  [Tooltip("If true the icons will be clamped in the border")]
  public bool clampIconInBorder = true;
  [Tooltip("Set the distance from target after which the icon will not be shown. Setting it 0 will always show the icon.")]
  public float clampDistance = 100f;
  private MiniMapController miniMapController;
  private MiniMapEntity mme;
  private MapObject mmo;

  private void OnEnable()
  {
    this.miniMapController = GameObject.Find("CanvasMiniMap").GetComponent<MiniMapController>();
    this.mme = new MiniMapEntity();
    this.mme.icon = this.icon;
    this.mme.rotation = this.initialIconRotation;
    this.mme.size = this.size;
    this.mme.upAxis = this.upAxis;
    this.mme.rotateWithObject = this.rotateWithObject;
    this.mme.clampInBorder = this.clampIconInBorder;
    this.mme.clampDist = this.clampDistance;
    this.mmo = this.miniMapController.RegisterMapObject(this.gameObject, this.mme);
  }

  private void OnDisable() => this.miniMapController.UnregisterMapObject(this.mmo, this.gameObject);

  private void OnDestroy()
  {
    if (!((Object) this.miniMapController != (Object) null))
      return;
    this.miniMapController.UnregisterMapObject(this.mmo, this.gameObject);
  }
}
