using UnityEngine;

public class RPG_Animation_CharacterFadeOnly : MonoBehaviour
{
	public static RPG_Animation_CharacterFadeOnly instance;

	private void Awake()
	{
		instance = this;
	}
}
