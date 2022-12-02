using UnityEngine;

public class ExpressionMaskScript : MonoBehaviour
{
	public Renderer Mask;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			if (ID < 3)
			{
				ID++;
			}
			else
			{
				ID = 0;
			}
			switch (ID)
			{
			case 0:
				Mask.material.mainTextureOffset = Vector2.zero;
				break;
			case 1:
				Mask.material.mainTextureOffset = new Vector2(0f, 0.5f);
				break;
			case 2:
				Mask.material.mainTextureOffset = new Vector2(0.5f, 0f);
				break;
			case 3:
				Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
				break;
			}
		}
	}
}
