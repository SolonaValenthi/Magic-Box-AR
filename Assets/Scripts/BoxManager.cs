using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private static BoxManager _instance;
    public static BoxManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No BoxManager found");

            return _instance;
        }
    }

    public delegate void OrderChecked();
    public static event OrderChecked correctOrder;
    public static event OrderChecked incorrectOrder;

    [SerializeField] private Animator _boxAnim;
    
    private int[] _correctOrder;
    private int[] _enteredOrder = { 0, 0, 0 };
    private int _gemsPressed = 0;

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _correctOrder = new int[3] { 2, 0, 1 };
    }

    public void GemPressed(int ID)
    {
        _enteredOrder[_gemsPressed] = ID;
        _gemsPressed++;

        if (_gemsPressed >= _correctOrder.Length)
            CheckOrder();
    }

    private void CheckOrder()
    {
        for (int i = 0; i < _correctOrder.Length; i++)
        {
            if (_enteredOrder[i] != _correctOrder[i])
            {
                _gemsPressed = 0;
                ResetBox();
                return;
            }
        }
        OpenBox();
    }

    private void OpenBox()
    {
        _boxAnim.SetTrigger("Open");
        correctOrder?.Invoke();
    }

    private void ResetBox()
    {
        incorrectOrder?.Invoke();
    }
}
