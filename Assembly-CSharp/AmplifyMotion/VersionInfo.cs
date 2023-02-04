using System;
using UnityEngine;

namespace AmplifyMotion
{
	[Serializable]
	public class VersionInfo
	{
		public const byte Major = 1;

		public const byte Minor = 8;

		public const byte Release = 3;

		private static string StageSuffix = "_dev001";

		private static string TrialSuffix = "";

		[SerializeField]
		private int m_major;

		[SerializeField]
		private int m_minor;

		[SerializeField]
		private int m_release;

		public int Number => m_major * 100 + m_minor * 10 + m_release;

		public static string StaticToString()
		{
			return $"{(byte)1}.{(byte)8}.{(byte)3}" + StageSuffix + TrialSuffix;
		}

		public override string ToString()
		{
			return $"{m_major}.{m_minor}.{m_release}" + StageSuffix + TrialSuffix;
		}

		private VersionInfo()
		{
			m_major = 1;
			m_minor = 8;
			m_release = 3;
		}

		private VersionInfo(byte major, byte minor, byte release)
		{
			m_major = major;
			m_minor = minor;
			m_release = release;
		}

		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		public static bool Matches(VersionInfo version)
		{
			if (1 == version.m_major && 8 == version.m_minor)
			{
				return 3 == version.m_release;
			}
			return false;
		}
	}
}
