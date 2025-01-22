using UnityEngine;

public class OnClickAdd : MonoBehaviour
{
    [SerializeField] private  GatherableScriptableObject _ressourceToAdd;

    private void OnMouseDown()
    {
        Debug.Log("Add "+ _ressourceToAdd.ressourceNameTag);
    }
}
