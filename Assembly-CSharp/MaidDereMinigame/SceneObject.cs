using System;
using UnityEngine;

namespace MaidDereMinigame
{
	[Serializable]
	[CreateAssetMenu(fileName = "New Scene Object", menuName = "Scenes/New Scene Object")]
	public class SceneObject : ScriptableObject
	{
		public int sceneBuildNumber = -1;
	}
}
