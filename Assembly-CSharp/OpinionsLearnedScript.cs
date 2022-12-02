using System;
using System.Collections.Generic;
using UnityEngine;

public class OpinionsLearnedScript : MonoBehaviour
{
	[Serializable]
	public struct Students
	{
		public List<bool> Opinions;
	}

	[SerializeField]
	public Students[] StudentOpinions;
}
