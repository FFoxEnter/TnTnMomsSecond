using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private string _url;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.source = VideoSource.Url;
        _videoPlayer.url = _url;

        _videoPlayer.Play();
    }
}