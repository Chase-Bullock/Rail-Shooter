using UnityEngine;
// ReSharper disable MemberCanBeMadeStatic.Local
// ReSharper disable ArrangeTypeMemberModifiers

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numOfMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if (numOfMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
