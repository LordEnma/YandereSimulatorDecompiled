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
	public Sprite miniMapMask;

	[Tooltip("border graphics of the minimap")]
	public Sprite miniMapBorder;

	[Tooltip("Set opacity of minimap")]
	[Range(0f, 1f)]
	public float miniMapOpacity = 1f;

	[Tooltip("border graphics of the minimap")]
	public Vector3 miniMapScale = new Vector3(1f, 1f, 1f);

	[Tooltip("Camera offset from the target")]
	public Vector3 cameraOffset = new Vector3(0f, 7.5f, 0f);

	[Tooltip("Camera's orthographic size")]
	public float camSize = 15f;

	[Tooltip("Camera's far clip")]
	public float camFarClip = 1000f;

	[Tooltip("Adjust the rotation according to your scene")]
	public Vector3 rotationOfCam = new Vector3(90f, 0f, 0f);

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
		ownerIconMap.Clear();
		GameObject gameObject = base.transform.GetComponentInChildren<Mask>().gameObject;
		mapPanelMask = gameObject.GetComponent<Image>();
		mapPanelBorder = gameObject.transform.parent.GetComponent<Image>();
		miniMapPanel = gameObject.transform.GetChild(0).gameObject;
		mapPanel = miniMapPanel.GetComponent<Image>();
		mapColor = mapPanel.color;
		mapBorderColor = mapPanelBorder.color;
		if (mapCamera == null)
		{
			mapCamera = base.transform.GetComponentInChildren<Camera>();
		}
		mapCamera.cullingMask = minimapLayers;
		mapPanelMaskRect = gameObject.GetComponent<RectTransform>();
		mapPanelRect = miniMapPanel.GetComponent<RectTransform>();
		mapPanelRect.anchoredPosition = mapPanelMaskRect.anchoredPosition;
		res = new Vector2(Screen.width, Screen.height);
		miniMapPanelImage = miniMapPanel.GetComponent<Image>();
		miniMapPanelImage.enabled = !showBackground;
		SetupRenderTexture();
	}

	private void OnDisable()
	{
		if (renderTex != null && !renderTex.IsCreated())
		{
			renderTex.Release();
		}
	}

	private void OnDestroy()
	{
		if (renderTex != null && !renderTex.IsCreated())
		{
			renderTex.Release();
		}
	}

	public void LateUpdate()
	{
		mapPanelMask.sprite = miniMapMask;
		mapPanelBorder.sprite = miniMapBorder;
		mapPanelBorder.rectTransform.localScale = miniMapScale;
		mapBorderColor.a = miniMapOpacity;
		mapColor.a = miniMapOpacity;
		mapPanelBorder.color = mapBorderColor;
		mapPanel.color = mapColor;
		mapPanelMaskRect.sizeDelta = new Vector2(Mathf.RoundToInt(mapPanelMaskRect.sizeDelta.x), Mathf.RoundToInt(mapPanelMaskRect.sizeDelta.y));
		mapPanelRect.position = mapPanelMaskRect.position;
		mapPanelRect.sizeDelta = mapPanelMaskRect.sizeDelta;
		miniMapPanelImage.enabled = !showBackground;
		if ((float)Screen.width != res.x || (float)Screen.height != res.y)
		{
			SetupRenderTexture();
			res.x = Screen.width;
			res.y = Screen.height;
		}
		SetCam();
	}

	private void SetupRenderTexture()
	{
		if (renderTex.IsCreated())
		{
			renderTex.Release();
		}
		renderTex = new RenderTexture((int)mapPanelRect.sizeDelta.x, (int)mapPanelRect.sizeDelta.y, 24);
		renderTex.Create();
		mapMaterial.mainTexture = renderTex;
		mapCamera.targetTexture = renderTex;
		mapPanelMaskRect.gameObject.SetActive(false);
		mapPanelMaskRect.gameObject.SetActive(true);
	}

	private void SetCam()
	{
		mapCamera.orthographicSize = camSize;
		mapCamera.farClipPlane = camFarClip;
		if (!(target == null))
		{
			mapCamera.transform.eulerAngles = rotationOfCam;
			if (rotateWithTarget)
			{
				mapCamera.transform.eulerAngles = target.eulerAngles + rotationOfCam;
			}
			mapCamera.transform.position = target.position + cameraOffset;
		}
	}

	public MapObject RegisterMapObject(GameObject owner, MiniMapEntity mme)
	{
		GameObject gameObject = Object.Instantiate(iconPref);
		gameObject.AddComponent<MapObject>().SetMiniMapEntityValues(this, mme, owner, mapCamera, miniMapPanel);
		ownerIconMap.Add(owner, gameObject);
		return owner.GetComponent<MapObject>();
	}

	public void UnregisterMapObject(MapObject mmo, GameObject owner)
	{
		if (ownerIconMap.ContainsKey(owner))
		{
			Object.Destroy(ownerIconMap[owner]);
			ownerIconMap.Remove(owner);
		}
		Object.Destroy(mmo);
	}
}
