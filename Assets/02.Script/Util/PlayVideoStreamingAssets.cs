using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoStreamingAssets : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private string _streamingAssetsMoviePath;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.source = VideoSource.Url;
        _videoPlayer.url = Path.Combine(Application.streamingAssetsPath, _streamingAssetsMoviePath);

        _videoPlayer.Play();
    }
}