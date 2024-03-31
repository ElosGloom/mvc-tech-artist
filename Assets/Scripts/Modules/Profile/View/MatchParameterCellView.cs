using TMPro;
using UnityEngine;
using Zenject;

namespace Modules.Profile.View
{
    public struct MatchParametersProtocol
    {
        public string Header;
        public string SubHeader;
        public string Score;
    }

    public class MatchParameterCellView : MonoBehaviour, IPoolable<MatchParametersProtocol, IMemoryPool>, IClearable
    {
        [SerializeField] private TextMeshProUGUI m_header;
        [SerializeField] private TextMeshProUGUI m_subHeader;
        [SerializeField] private TextMeshProUGUI m_score;
    
        private IMemoryPool m_pool;

    
        public void OnSpawned(MatchParametersProtocol protocol, IMemoryPool pool)
        {
            m_pool = pool;
            m_header.text = protocol.Header;
            m_subHeader.text = protocol.SubHeader;
            m_score.text = protocol.Score;
        }

        public void OnDespawned()
        {
            m_pool = null;
        }

        public void Clear()
        {
            m_pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<MatchParametersProtocol, MatchParameterCellView>
        {
        }

        public class Pool : MonoPoolableMemoryPool<MatchParametersProtocol, IMemoryPool, MatchParameterCellView>
        {
        }
    }
}