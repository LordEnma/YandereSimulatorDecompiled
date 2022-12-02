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
		if (owner == null)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			SetPositionAndRotation();
		}
	}

	public void SetMiniMapEntityValues(MiniMapController controller, MiniMapEntity mme, GameObject attachedGO, Camera renderCamera, GameObject parentPanelGO)
	{
		linkedMiniMapEntity = mme;
		owner = attachedGO;
		mapCamera = renderCamera;
		panelGO = parentPanelGO;
		spr = base.gameObject.GetComponent<Image>();
		spr.sprite = mme.icon;
		sprRect = spr.gameObject.GetComponent<RectTransform>();
		sprRect.sizeDelta = mme.size;
		rt = panelGO.GetComponent<RectTransform>();
		mmc = controller;
		miniMapTarget = mmc.target;
		SetPositionAndRotation();
	}

	private void SetPositionAndRotation()
	{
		base.transform.SetParent(panelGO.transform, false);
		SetPosition();
		SetRotation();
	}

	private void SetPosition()
	{
		cornerss = new Vector3[4];
		rt.GetWorldCorners(cornerss);
		screenPos = RectTransformUtility.WorldToScreenPoint(mapCamera, owner.transform.position);
		if (linkedMiniMapEntity.clampInBorder && Mathf.Abs(Vector3.Distance(owner.transform.position, mmc.target.transform.position)) < linkedMiniMapEntity.clampDist)
		{
			ClampIconColliderWise();
		}
		else
		{
			sprRect.anchoredPosition = screenPos - rt.sizeDelta / 2f;
		}
	}

	private void ClampIconColliderWise()
	{
		sprRect.anchoredPosition = screenPos - rt.sizeDelta / 2f;
		Vector2 direction = rt.position - sprRect.position;
		RaycastHit2D[] array = Physics2D.RaycastAll(sprRect.position, direction);
		if (array.Length == 0)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].transform.name == mmc.shapeColliderGO.name)
			{
				sprRect.position = array[i].point;
				break;
			}
		}
	}

	private void SetRotation()
	{
		if (linkedMiniMapEntity.rotateWithObject)
		{
			if (Mathf.Abs(linkedMiniMapEntity.upAxis.y) == 1f)
			{
				if (mmc.rotateWithTarget)
				{
					sprRect.localEulerAngles = new Vector3(0f, 0f, linkedMiniMapEntity.upAxis.y * (miniMapTarget.transform.localEulerAngles.y - mmc.rotationOfCam.z - owner.transform.localEulerAngles.y) + linkedMiniMapEntity.rotation);
				}
				else
				{
					sprRect.localEulerAngles = new Vector3(0f, 0f, (0f - linkedMiniMapEntity.upAxis.y) * owner.transform.localEulerAngles.y + linkedMiniMapEntity.rotation);
				}
			}
			else if (Mathf.Abs(linkedMiniMapEntity.upAxis.z) == 1f)
			{
				if (mmc.rotateWithTarget)
				{
					sprRect.localEulerAngles = new Vector3(0f, 0f, linkedMiniMapEntity.upAxis.z * (miniMapTarget.transform.localEulerAngles.z - mmc.rotationOfCam.z - owner.transform.localEulerAngles.z) + linkedMiniMapEntity.rotation);
				}
				else
				{
					sprRect.localEulerAngles = new Vector3(0f, 0f, (0f - linkedMiniMapEntity.upAxis.z) * owner.transform.localEulerAngles.z + linkedMiniMapEntity.rotation);
				}
			}
			else if (Mathf.Abs(linkedMiniMapEntity.upAxis.x) == 1f)
			{
				if (mmc.rotateWithTarget)
				{
					sprRect.localEulerAngles = new Vector3(0f, 0f, linkedMiniMapEntity.upAxis.x * (miniMapTarget.transform.localEulerAngles.x - mmc.rotationOfCam.z - owner.transform.localEulerAngles.x) + linkedMiniMapEntity.rotation);
				}
				else
				{
					sprRect.localEulerAngles = new Vector3(0f, 0f, (0f - linkedMiniMapEntity.upAxis.x) * owner.transform.localEulerAngles.x + linkedMiniMapEntity.rotation);
				}
			}
		}
		else if (Mathf.Abs(linkedMiniMapEntity.upAxis.y) == 1f)
		{
			sprRect.localEulerAngles = new Vector3(0f, 0f, sprRect.localEulerAngles.y + linkedMiniMapEntity.rotation);
		}
		else if (Mathf.Abs(linkedMiniMapEntity.upAxis.z) == 1f)
		{
			sprRect.localEulerAngles = new Vector3(0f, 0f, sprRect.localEulerAngles.z + linkedMiniMapEntity.rotation);
		}
		else if (Mathf.Abs(linkedMiniMapEntity.upAxis.x) == 1f)
		{
			sprRect.localEulerAngles = new Vector3(0f, 0f, sprRect.localEulerAngles.x + linkedMiniMapEntity.rotation);
		}
	}
}
