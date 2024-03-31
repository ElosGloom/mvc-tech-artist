using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.Profile.View
{
    public struct AchievementCellProtocol
    {
        public string AchievementName;
        public string Date;
        public Sprite Icon;
    }

    public class AchievementCellView : MonoBehaviour, IPoolable<AchievementCellProtocol, IMemoryPool>
    {
        [SerializeField] private TextMeshProUGUI m_name;
        [SerializeField] private TextMeshProUGUI m_date;
        [SerializeField] private Image m_icon;

        private IMemoryPool _pool;


        public void OnSpawned(AchievementCellProtocol protocol, IMemoryPool pool)
        {
            _pool = pool;
            m_name.text = protocol.AchievementName;
            m_date.text = protocol.Date;
            m_icon.sprite = protocol.Icon;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public class Factory : PlaceholderFactory<AchievementCellProtocol, AchievementCellView>
        {
        }

        public class Pool : MonoPoolableMemoryPool<AchievementCellProtocol, IMemoryPool, AchievementCellView>
        {
        }

    }
}