using UnityEngine;

public class SimpleDetectClickScript : MonoBehaviour
{
	public InventoryItemScript InventoryItem;

	public Collider MyCollider;

	public bool Clicked;

	private void Update()
	{
		RaycastHit hitInfo;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 100f) && hitInfo.collider == MyCollider)
		{
			Clicked = true;
		}
	}
}
