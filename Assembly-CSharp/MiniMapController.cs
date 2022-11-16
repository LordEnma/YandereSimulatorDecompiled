// Decompiled with JetBrains decompiler
// Type: MiniMapController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MiniMapController : MonoBehaviour
{
  [HideInInspector]
  public Transform shapeColliderGO;
  public RenderTexture renderTex;
  public Material mapMaterial;
  [HideInInspector]
  public List<MiniMapEntity> miniMapEntities;
  public GameObject iconPref;
  [HideInInspector]
  public Camera mapCamera;
  [Tooltip("The target which the minimap will be following")]
  public Transform target;
  [Tooltip("Set which layers to show in the minimap")]
  public LayerMask minimapLayers;
  [Tooltip("Set this true, if you want minimap border as background of minimap")]
  public bool showBackground;
  [Tooltip("The mask to change the shape of minimap")]
  public UnityEngine.Sprite miniMapMask;
  [Tooltip("border graphics of the minimap")]
  public UnityEngine.Sprite miniMapBorder;
  [Tooltip("Set opacity of minimap")]
  [Range(0.0f, 1f)]
  public float miniMapOpacity = 1f;
  [Tooltip("border graphics of the minimap")]
  public Vector3 miniMapScale = new Vector3(1f, 1f, 1f);
  [Tooltip("Camera offset from the target")]
  public Vector3 cameraOffset = new Vector3(0.0f, 7.5f, 0.0f);
  [Tooltip("Camera's orthographic size")]
  public float camSize = 15f;
  [Tooltip("Camera's far clip")]
  public float camFarClip = 1000f;
  [Tooltip("Adjust the rotation according to your scene")]
  public Vector3 rotationOfCam = new Vector3(90f, 0.0f, 0.0f);
  [Tooltip("If true the camera rotates according to the target")]
  public bool rotateWithTarget = true;
  [HideInInspector]
  public Dictionary<GameObject, GameObject> ownerIconMap = new Dictionary<GameObject, GameObject>();
  private GameObject miniMapPanel;
  private Image mapPanelMask;
  private Image mapPanelBorder;
  private Image mapPanel;
  private Color mapColor;
  private Color mapBorderColor;
  private RectTransform mapPanelRect;
  private RectTransform mapPanelMaskRect;
  private Vector3 prevRotOfCam;
  private Vector2 res;
  private Image miniMapPanelImage;

  public void OnEnable()
  {
    this.ownerIconMap.Clear();
    GameObject gameObject = this.transform.GetComponentInChildren<Mask>().gameObject;
    this.mapPanelMask = gameObject.GetComponent<Image>();
    this.mapPanelBorder = gameObject.transform.parent.GetComponent<Image>();
    this.miniMapPanel = gameObject.transform.GetChild(0).gameObject;
    this.mapPanel = this.miniMapPanel.GetComponent<Image>();
    this.mapColor = this.mapPanel.color;
    this.mapBorderColor = this.mapPanelBorder.color;
    if ((Object) this.mapCamera == (Object) null)
      this.mapCamera = this.transform.GetComponentInChildren<Camera>();
    this.mapCamera.cullingMask = (int) this.minimapLayers;
    this.mapPanelMaskRect = gameObject.GetComponent<RectTransform>();
    this.mapPanelRect = this.miniMapPanel.GetComponent<RectTransform>();
    this.mapPanelRect.anchoredPosition = this.mapPanelMaskRect.anchoredPosition;
    this.res = new Vector2((float) Screen.width, (float) Screen.height);
    this.miniMapPanelImage = this.miniMapPanel.GetComponent<Image>();
    this.miniMapPanelImage.enabled = !this.showBackground;
    this.SetupRenderTexture();
  }

  private void OnDisable()
  {
    if (!((Object) this.renderTex != (Object) null) || this.renderTex.IsCreated())
      return;
    this.renderTex.Release();
  }

  private void OnDestroy()
  {
    if (!((Object) this.renderTex != (Object) null) || this.renderTex.IsCreated())
      return;
    this.renderTex.Release();
  }

  public void LateUpdate()
  {
    this.mapPanelMask.sprite = this.miniMapMask;
    this.mapPanelBorder.sprite = this.miniMapBorder;
    this.mapPanelBorder.rectTransform.localScale = this.miniMapScale;
    this.mapBorderColor.a = this.miniMapOpacity;
    this.mapColor.a = this.miniMapOpacity;
    this.mapPanelBorder.color = this.mapBorderColor;
    this.mapPanel.color = this.mapColor;
    this.mapPanelMaskRect.sizeDelta = new Vector2((float) Mathf.RoundToInt(this.mapPanelMaskRect.sizeDelta.x), (float) Mathf.RoundToInt(this.mapPanelMaskRect.sizeDelta.y));
    this.mapPanelRect.position = this.mapPanelMaskRect.position;
    this.mapPanelRect.sizeDelta = this.mapPanelMaskRect.sizeDelta;
    this.miniMapPanelImage.enabled = !this.showBackground;
    if ((double) Screen.width != (double) this.res.x || (double) Screen.height != (double) this.res.y)
    {
      this.SetupRenderTexture();
      this.res.x = (float) Screen.width;
      this.res.y = (float) Screen.height;
    }
    this.SetCam();
  }

  private void SetupRenderTexture()
  {
    if (this.renderTex.IsCreated())
      this.renderTex.Release();
    this.renderTex = new RenderTexture((int) this.mapPanelRect.sizeDelta.x, (int) this.mapPanelRect.sizeDelta.y, 24);
    this.renderTex.Create();
    this.mapMaterial.mainTexture = (Texture) this.renderTex;
    this.mapCamera.targetTexture = this.renderTex;
    this.mapPanelMaskRect.gameObject.SetActive(false);
    this.mapPanelMaskRect.gameObject.SetActive(true);
  }

  private void SetCam()
  {
    this.mapCamera.orthographicSize = this.camSize;
    this.mapCamera.farClipPlane = this.camFarClip;
    if ((Object) this.target == (Object) null)
      return;
    this.mapCamera.transform.eulerAngles = this.rotationOfCam;
    if (this.rotateWithTarget)
      this.mapCamera.transform.eulerAngles = this.target.eulerAngles + this.rotationOfCam;
    this.mapCamera.transform.position = this.target.position + this.cameraOffset;
  }

  public MapObject RegisterMapObject(GameObject owner, MiniMapEntity mme)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(this.iconPref);
    gameObject.AddComponent<MapObject>().SetMiniMapEntityValues(this, mme, owner, this.mapCamera, this.miniMapPanel);
    this.ownerIconMap.Add(owner, gameObject);
    return owner.GetComponent<MapObject>();
  }

  public void UnregisterMapObject(MapObject mmo, GameObject owner)
  {
    if (this.ownerIconMap.ContainsKey(owner))
    {
      Object.Destroy((Object) this.ownerIconMap[owner]);
      this.ownerIconMap.Remove(owner);
    }
    Object.Destroy((Object) mmo);
  }
}
