using UnityEngine;

public class BagButton : MonoBehaviour
{
    private bool _isActive = false;
    public void OpenOrCloseBag()
    {
        _isActive = !_isActive;
        gameObject.SetActive(_isActive);
    }
}
