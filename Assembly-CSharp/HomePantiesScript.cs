using UnityEngine;

public class HomePantiesScript : MonoBehaviour
{
	public HomePantyChangerScript PantyChanger;

	public float RotationSpeed;

	public Material Unselectable;

	public Renderer MyRenderer;

	public int ID;

	private void Start()
	{
		if (ID > 0 && !CollectibleGlobals.GetPantyPurchased(ID))
		{
			MyRenderer.material = Unselectable;
			MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	private void Update()
	{
		float y = ((PantyChanger.Selected == ID) ? (base.transform.eulerAngles.y + Time.deltaTime * RotationSpeed) : 0f);
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}
}
