using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;
    private RawImage _image;
    private float _imageX;
    private void Start()
    {
        _image = GetComponent<RawImage>();
        _imageX = _image.uvRect.x;
    }
    private void Update()
    {
        _imageX += _speed * Time.deltaTime;
        if (_imageX > 10) _imageX = 0;
        _image.uvRect = new Rect(_imageX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
