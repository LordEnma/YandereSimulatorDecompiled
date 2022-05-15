using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000545 RID: 1349
	public static class CrossPlatformInputManager
	{
		// Token: 0x0600225F RID: 8799 RVA: 0x001F5BF9 File Offset: 0x001F3DF9
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x001F5C19 File Offset: 0x001F3E19
		public static void SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod activeInputMethod)
		{
			if (activeInputMethod == CrossPlatformInputManager.ActiveInputMethod.Hardware)
			{
				CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
				return;
			}
			if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Touch)
			{
				return;
			}
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x001F5C38 File Offset: 0x001F3E38
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001F5C45 File Offset: 0x001F3E45
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001F5C52 File Offset: 0x001F3E52
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001F5C5F File Offset: 0x001F3E5F
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x001F5C6C File Offset: 0x001F3E6C
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x001F5C87 File Offset: 0x001F3E87
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x001F5C94 File Offset: 0x001F3E94
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x001F5CA1 File Offset: 0x001F3EA1
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x001F5CAA File Offset: 0x001F3EAA
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001F5CB3 File Offset: 0x001F3EB3
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001F5CC1 File Offset: 0x001F3EC1
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001F5CCE File Offset: 0x001F3ECE
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x001F5CDB File Offset: 0x001F3EDB
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x001F5CE8 File Offset: 0x001F3EE8
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001F5CF5 File Offset: 0x001F3EF5
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x001F5D02 File Offset: 0x001F3F02
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x001F5D0F File Offset: 0x001F3F0F
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x001F5D1C File Offset: 0x001F3F1C
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001F5D29 File Offset: 0x001F3F29
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06002274 RID: 8820 RVA: 0x001F5D37 File Offset: 0x001F3F37
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002275 RID: 8821 RVA: 0x001F5D43 File Offset: 0x001F3F43
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x001F5D50 File Offset: 0x001F3F50
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x001F5D5D File Offset: 0x001F3F5D
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004B36 RID: 19254
		private static VirtualInput activeInput;

		// Token: 0x04004B37 RID: 19255
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004B38 RID: 19256
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000693 RID: 1683
		public enum ActiveInputMethod
		{
			// Token: 0x040050F9 RID: 20729
			Hardware,
			// Token: 0x040050FA RID: 20730
			Touch
		}

		// Token: 0x02000694 RID: 1684
		public class VirtualAxis
		{
			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x0600274B RID: 10059 RVA: 0x00209343 File Offset: 0x00207543
			// (set) Token: 0x0600274C RID: 10060 RVA: 0x0020934B File Offset: 0x0020754B
			public string name { get; private set; }

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x0600274D RID: 10061 RVA: 0x00209354 File Offset: 0x00207554
			// (set) Token: 0x0600274E RID: 10062 RVA: 0x0020935C File Offset: 0x0020755C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x0600274F RID: 10063 RVA: 0x00209365 File Offset: 0x00207565
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x06002750 RID: 10064 RVA: 0x0020936F File Offset: 0x0020756F
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x06002751 RID: 10065 RVA: 0x00209385 File Offset: 0x00207585
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x06002752 RID: 10066 RVA: 0x00209392 File Offset: 0x00207592
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000584 RID: 1412
			// (get) Token: 0x06002753 RID: 10067 RVA: 0x0020939B File Offset: 0x0020759B
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06002754 RID: 10068 RVA: 0x002093A3 File Offset: 0x002075A3
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x040050FC RID: 20732
			private float m_Value;
		}

		// Token: 0x02000695 RID: 1685
		public class VirtualButton
		{
			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002755 RID: 10069 RVA: 0x002093AB File Offset: 0x002075AB
			// (set) Token: 0x06002756 RID: 10070 RVA: 0x002093B3 File Offset: 0x002075B3
			public string name { get; private set; }

			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002757 RID: 10071 RVA: 0x002093BC File Offset: 0x002075BC
			// (set) Token: 0x06002758 RID: 10072 RVA: 0x002093C4 File Offset: 0x002075C4
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06002759 RID: 10073 RVA: 0x002093CD File Offset: 0x002075CD
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x0600275A RID: 10074 RVA: 0x002093D7 File Offset: 0x002075D7
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x0600275B RID: 10075 RVA: 0x002093FD File Offset: 0x002075FD
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x0600275C RID: 10076 RVA: 0x0020941A File Offset: 0x0020761A
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x0600275D RID: 10077 RVA: 0x0020942E File Offset: 0x0020762E
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600275E RID: 10078 RVA: 0x0020943B File Offset: 0x0020763B
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x0600275F RID: 10079 RVA: 0x00209443 File Offset: 0x00207643
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x06002760 RID: 10080 RVA: 0x00209454 File Offset: 0x00207654
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04005100 RID: 20736
			private int m_LastPressedFrame = -5;

			// Token: 0x04005101 RID: 20737
			private int m_ReleasedFrame = -5;

			// Token: 0x04005102 RID: 20738
			private bool m_Pressed;
		}
	}
}
