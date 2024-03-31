using Modules.Profile.View;
using UI;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindFactory<AchievementsGroupView, AchievementsGroupView.Factory>()
            .FromPoolableMemoryPool<AchievementsGroupView, AchievementsGroupView.Pool>(
                poolBinder =>
                    poolBinder
                        .WithInitialSize(4)
                        .FromComponentInNewPrefabResource($"Poolables/{nameof(AchievementsGroupView)}")
                        .UnderTransformGroup(nameof(AchievementsGroupView)));


        Container.BindFactory<AchievementCellProtocol, AchievementCellView, AchievementCellView.Factory>()
            .FromPoolableMemoryPool<AchievementCellProtocol, AchievementCellView, AchievementCellView.Pool>(
                poolBinder =>
                    poolBinder
                        .WithInitialSize(5)
                        .FromComponentInNewPrefabResource($"Poolables/{nameof(AchievementCellView)}")
                        .UnderTransformGroup(nameof(AchievementCellView)));

        Container.BindFactory<MatchButtonProtocol, MatchButtonView, MatchButtonView.Factory>()
            .FromPoolableMemoryPool<MatchButtonProtocol, MatchButtonView, MatchButtonView.Pool>(poolBinder =>
                poolBinder
                    .WithInitialSize(3)
                    .FromComponentInNewPrefabResource($"Poolables/{nameof(MatchButtonView)}")
                    .UnderTransformGroup(nameof(MatchButtonView)));

        Container.BindFactory<MatchParametersProtocol, MatchParameterCellView, MatchParameterCellView.Factory>()
            .FromPoolableMemoryPool<MatchParametersProtocol, MatchParameterCellView, MatchParameterCellView.Pool>(
                poolBinder =>
                    poolBinder
                        .WithInitialSize(3)
                        .FromComponentInNewPrefabResource($"Poolables/{nameof(MatchParameterCellView)}")
                        .UnderTransformGroup(nameof(MatchParameterCellView)));
    }
}