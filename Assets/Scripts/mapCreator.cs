using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class mapCreator : MonoBehaviour

{
    [SerializeField]
    private string _path = Path.Combine(Application.dataPath, "Sprites");

    [SerializeField]
    private int _resolution = 5;

    [SerializeField]
    private List<LayerMask> _layersList = new List<LayerMask>();

    private List<RenderTexture> _texturesList = new List<RenderTexture>();

    private Camera _camera;

    private void Awake()
    {
        FindMapCamera();
    }

    void Start ()
    {
        for(int i=0; i < _layersList.Count; i++)
        {
            var filename = String.Format("map{0}.png", i+1);
            _camera.cullingMask = 0;
            _camera.cullingMask = 1 << _layersList[i];
            _texturesList.Add(new RenderTexture(256, 256 , 0));
            _camera.targetTexture = _texturesList[i];
            ScreenCapture.CaptureScreenshot(Path.Combine(_path, filename),
            _resolution);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FindMapCamera()
    {
        var camerasArray = Camera.allCameras;
        foreach (var obj in camerasArray)
        {
            if (obj.tag.Equals("mapCam"))
            {
                _camera = obj;
                return;
            }
        }
    }
}
