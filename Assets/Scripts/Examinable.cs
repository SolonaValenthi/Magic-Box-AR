using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    private Vector3 _returnPos;
    private Quaternion _returnRot;
    private Vector3 _returnScale;

    public void Examine()
    {
        SetReturn();
        ExaminableManager.Instance.SetExamineTarget(this.transform);
    }

    public void Unexamine()
    {
        ReturnToWorld();
    }

    private void SetReturn()
    {
        _returnPos = transform.position;
        _returnRot = transform.rotation;
        _returnScale = transform.localScale;
    }

    private void ReturnToWorld()
    {
        transform.parent = null;
        transform.position = _returnPos;
        transform.rotation = _returnRot;
        transform.localScale = _returnScale;
    }
}
