using UnityEngine;

public class SimpleDetectClickScript : MonoBehaviour
{
	public InventoryItemScript InventoryItem;

	public Collider MyCollider;

	public bool Clicked;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 100f) && hitInfo.collider == MyCollider)
		{
			Clicked = true;
		}
	}
}
