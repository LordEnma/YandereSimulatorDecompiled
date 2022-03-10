using System;
using System.Xml.Serialization;

// Token: 0x02000409 RID: 1033
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x040031B0 RID: 12720
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x040031B1 RID: 12721
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x040031B2 RID: 12722
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x040031B3 RID: 12723
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x040031B4 RID: 12724
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x040031B5 RID: 12725
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x040031B6 RID: 12726
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x040031B7 RID: 12727
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x040031B8 RID: 12728
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x040031B9 RID: 12729
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x040031BA RID: 12730
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x040031BB RID: 12731
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x040031BC RID: 12732
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x040031BD RID: 12733
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x040031BE RID: 12734
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x040031BF RID: 12735
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x040031C0 RID: 12736
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x040031C1 RID: 12737
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x040031C2 RID: 12738
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x040031C3 RID: 12739
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x040031C4 RID: 12740
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
