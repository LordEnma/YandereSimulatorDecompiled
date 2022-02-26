using System;
using System.Xml.Serialization;

// Token: 0x02000409 RID: 1033
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x0400319A RID: 12698
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x0400319B RID: 12699
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x0400319C RID: 12700
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x0400319D RID: 12701
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x0400319E RID: 12702
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x0400319F RID: 12703
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x040031A0 RID: 12704
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x040031A1 RID: 12705
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x040031A2 RID: 12706
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x040031A3 RID: 12707
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x040031A4 RID: 12708
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x040031A5 RID: 12709
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x040031A6 RID: 12710
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x040031A7 RID: 12711
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x040031A8 RID: 12712
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x040031A9 RID: 12713
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x040031AA RID: 12714
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x040031AB RID: 12715
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x040031AC RID: 12716
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x040031AD RID: 12717
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x040031AE RID: 12718
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
