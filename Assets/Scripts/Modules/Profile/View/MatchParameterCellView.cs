using TMPro;
using UnityEngine;
using Zenject;

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
    
    
    private IMemoryPool _pool;

    public void OnSpawned(MatchParametersProtocol protocol, IMemoryPool pool)
    {
        _pool = pool;
        m_header.text = protocol.Header;
        m_subHeader.text = protocol.SubHeader;
        m_score.text = protocol.Score;
    }

    public void OnDespawned()
    {
        _pool = null;
    }

    public void Clear()
    {
        _pool.Despawn(this);
    }

    public class Factory : PlaceholderFactory<MatchParametersProtocol, MatchParameterCellView>
    {
    }

    public class Pool : MonoPoolableMemoryPool<MatchParametersProtocol, IMemoryPool, MatchParameterCellView>
    {
    }

}