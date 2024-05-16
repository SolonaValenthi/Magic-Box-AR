using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;

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

    [SerializeField] private ARPlacementInteractable _placement;
    [SerializeField] private Transform _examineTarget;

    private GameObject _lastPlaceable;

    void Awake()
    {
        _instance = this;
    }

    public void SetExamineTarget(Transform target)
    {
        target.position = _examineTarget.position;
        target.parent = _examineTarget;
        _lastPlaceable = _placement.placementPrefab;
        _placement.placementPrefab = null;
    }

    public void EndExamination()
    {
        _placement.placementPrefab = _lastPlaceable;
    }
}
