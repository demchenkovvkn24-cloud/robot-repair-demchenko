using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10; персонаж почав рухатись дуже повільно
        MoveAction.Enable();
    }
    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position
        + move * 0.01f; //move * 3.0f * Time.deltaTime; персонаж рухається ривками
        transform.position = position;
    }
}