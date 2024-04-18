using UnityEngine;

public class ChangeShaderInChildrenScript : MonoBehaviour
{
	public Shader shaderToAssign;

	private void Start()
	{
		AssignShaderToAllChildren(base.transform);
	}

	private void AssignShaderToAllChildren(Transform parentTransform)
	{
		foreach (Transform item in parentTransform)
		{
			Renderer component = item.GetComponent<Renderer>();
			if (component != null)
			{
				Material[] materials = component.materials;
				for (int i = 0; i < materials.Length; i++)
				{
					materials[i].shader = shaderToAssign;
				}
			}
			AssignShaderToAllChildren(item);
		}
	}
}
