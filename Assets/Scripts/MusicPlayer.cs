using UnityEngine;
// ReSharper disable MemberCanBeMadeStatic.Local
// ReSharper disable ArrangeTypeMemberModifiers

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
