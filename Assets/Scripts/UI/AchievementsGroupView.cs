using Modules.Profile.View;
using UnityEngine;
using Zenject;

namespace UI
{
    public class AchievementsGroupView : MonoBehaviour, IPoolable<IMemoryPool>
    {
        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void AddCell(AchievementCellView achievementCell)
        {
            achievementCell.transform.SetParent(transform);
        }

        public class Factory : PlaceholderFactory<AchievementsGroupView>
        {
        }

        public class Pool : MonoPoolableMemoryPool<IMemoryPool, AchievementsGroupView>
        {
        }

    }
}