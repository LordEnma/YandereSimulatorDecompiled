using UnityEngine;

public class MiniMapComponent : MonoBehaviour
{
	[Tooltip("Set the icon of this gameobject")]
	public Sprite icon;

	[Tooltip("Set size of the icon")]
	public Vector2 size = new Vector2(20f, 20f);

	[Tooltip("Set true if the icon rotates with the gameobject")]
	public bool rotateWithObject;

	[Tooltip("Adjust the rotation axis according to your gameobject. Values of each axis can be either -1,0 or 1")]
	public Vector3 upAxis = new Vector3(0f, 1f, 0f);

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
		miniMapController = GameObject.Find("CanvasMiniMap").GetComponent<MiniMapController>();
		mme = new MiniMapEntity();
		mme.icon = icon;
		mme.rotation = initialIconRotation;
		mme.size = size;
		mme.upAxis = upAxis;
		mme.rotateWithObject = rotateWithObject;
		mme.clampInBorder = clampIconInBorder;
		mme.clampDist = clampDistance;
		mmo = miniMapController.RegisterMapObject(base.gameObject, mme);
	}

	private void OnDisable()
	{
		miniMapController.UnregisterMapObject(mmo, base.gameObject);
	}

	private void OnDestroy()
	{
		if (miniMapController != null)
		{
			miniMapController.UnregisterMapObject(mmo, base.gameObject);
		}
	}
}
