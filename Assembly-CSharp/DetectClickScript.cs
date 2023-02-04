using UnityEngine;

public class DetectClickScript : MonoBehaviour
{
	public Vector3 OriginalPosition;

	public Color OriginalColor;

	public Collider MyCollider;

	public Camera GUICamera;

	public UISprite Sprite;

	public UILabel Label;

	public bool Clicked;

	private void Start()
	{
		OriginalPosition = base.transform.localPosition;
		OriginalColor = Sprite.color;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(GUICamera.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100f) && hitInfo.collider == MyCollider && Label.color.a == 1f)
		{
			Sprite.color = new Color(1f, 1f, 1f, 1f);
			Clicked = true;
		}
	}

	private void OnTriggerEnter()
	{
		if (Label.color.a == 1f)
		{
			Sprite.color = Color.white;
		}
	}

	private void OnTriggerExit()
	{
		Sprite.color = OriginalColor;
	}
}
