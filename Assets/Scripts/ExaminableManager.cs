using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    private static ExaminableManager _instance;
    public static ExaminableManager Instance
    {
        get 
        {
            if (_instance == null)
                Debug.LogError("No examinable manager found");

            return _instance;
        }
    }

    [SerializeField] private Transform _examineTarget;

    void Awake()
    {
        _instance = this;
    }

    public void SetExamineTarget(Transform target)
    {
        target.position = _examineTarget.position;
        target.parent = _examineTarget;
    }
}
