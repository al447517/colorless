using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorInput : MonoBehaviour
{
    private InputAction MoveLeftAction;
    private InputAction MoveRightAction;
    private InputAction AttackAction;
    private InputAction JumpAction;

    public bool IsLeftPressed;
    public bool IsRightPressed;

    public bool IsJumpPressed;
    public bool IsAttackPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveLeftAction=InputSystem.actions.FindAction("MoveLeft");
        MoveRightAction=InputSystem.actions.FindAction("MoveRight");
        AttackAction=InputSystem.actions.FindAction("Attack");
        JumpAction=InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        IsLeftPressed=MoveLeftAction.IsPressed();
        IsRightPressed=MoveRightAction.IsPressed();
        IsAttackPressed=AttackAction.WasPressedThisFrame();
        IsJumpPressed=JumpAction.WasPressedThisFrame();
    }
}
