//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Script/System/Player Control/Player.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputSystem : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7831bbc2-6dde-4d26-8748-2d393706f57b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c0f64053-224c-4ce0-9ae8-eb91b0954d70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LightAttack"",
                    ""type"": ""Button"",
                    ""id"": ""2c7d1e13-72f9-4353-8465-2b4826f44f86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockTarget"",
                    ""type"": ""Value"",
                    ""id"": ""1fe35b52-b139-4bdf-826a-6f9734b35670"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ReleaseLock"",
                    ""type"": ""Button"",
                    ""id"": ""35ddb706-0187-48f4-9c35-28637ea25c3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""52b7cc2f-b3c3-47aa-a345-ea2d2394cc3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillPalette1"",
                    ""type"": ""Button"",
                    ""id"": ""fb1255e8-8935-432f-a822-35243925f541"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SkillPalette2"",
                    ""type"": ""Button"",
                    ""id"": ""4c3ef4a1-b2cb-4a34-8ada-5d637def1c04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SkillPalette3"",
                    ""type"": ""Button"",
                    ""id"": ""ba3fa519-1647-43eb-93af-9e7187cb1a49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SkillPalette4"",
                    ""type"": ""Button"",
                    ""id"": ""67c60193-3744-4c1b-ae08-4346e142691d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c13fae9-aa8d-4689-97c8-163acb6baece"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b9772af4-f800-4803-af3d-ec5d15de54a0"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""faf5b95c-bb68-47c6-ada7-a5b469df9da8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a2a3b87-25f7-4978-a565-dc09d0dc98d2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d187dacf-2788-401e-8ccb-0a752ec0eacb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3de6f30e-1a4f-4058-a7f0-881410ee636f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a078f422-2295-47ed-9aff-9f023e974e62"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""LockTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75a43623-7eee-4d1f-b6aa-bb61e61b87ba"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""ReleaseLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a10a9378-c14c-4318-87d5-6072a650154b"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""ReleaseLock"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07f6d5f4-9bd6-4339-b91a-355b54ffd6f8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40b6baf9-b4c2-44c5-bbdd-89cf51234872"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ddc33d8-b67d-4912-be81-c5e1059f9d0c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""053b5932-5bb4-4d71-9e77-2cea3389ce7c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1c53733-94a9-4c3c-b074-d72fc96d5444"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""SkillPalette1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01fcae7c-6072-4f96-a880-c3652fe09170"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""SkillPalette1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d8e974e-33bb-4425-b7ee-bebf991d2b0e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""SkillPalette2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01a46b0e-b8f9-4137-b817-3ad60b894773"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""SkillPalette2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdf2f8f4-25e7-4bff-894c-cf1807c829c2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""SkillPalette3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5adde8bc-b898-45d3-9f82-e8f40eb30eb5"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""SkillPalette3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84bf9497-acd9-4c20-9f15-5bb1dbc68f84"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""SkillPalette4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""500c02be-9c51-4845-8cba-74f8f54ebf61"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & mouse"",
                    ""action"": ""SkillPalette4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & mouse"",
            ""bindingGroup"": ""Keyboard & mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<AndroidJoystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_LightAttack = m_Player.FindAction("LightAttack", throwIfNotFound: true);
        m_Player_LockTarget = m_Player.FindAction("LockTarget", throwIfNotFound: true);
        m_Player_ReleaseLock = m_Player.FindAction("ReleaseLock", throwIfNotFound: true);
        m_Player_SwitchWeapon = m_Player.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_Player_SkillPalette1 = m_Player.FindAction("SkillPalette1", throwIfNotFound: true);
        m_Player_SkillPalette2 = m_Player.FindAction("SkillPalette2", throwIfNotFound: true);
        m_Player_SkillPalette3 = m_Player.FindAction("SkillPalette3", throwIfNotFound: true);
        m_Player_SkillPalette4 = m_Player.FindAction("SkillPalette4", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_LightAttack;
    private readonly InputAction m_Player_LockTarget;
    private readonly InputAction m_Player_ReleaseLock;
    private readonly InputAction m_Player_SwitchWeapon;
    private readonly InputAction m_Player_SkillPalette1;
    private readonly InputAction m_Player_SkillPalette2;
    private readonly InputAction m_Player_SkillPalette3;
    private readonly InputAction m_Player_SkillPalette4;
    public struct PlayerActions
    {
        private @PlayerInputSystem m_Wrapper;
        public PlayerActions(@PlayerInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @LightAttack => m_Wrapper.m_Player_LightAttack;
        public InputAction @LockTarget => m_Wrapper.m_Player_LockTarget;
        public InputAction @ReleaseLock => m_Wrapper.m_Player_ReleaseLock;
        public InputAction @SwitchWeapon => m_Wrapper.m_Player_SwitchWeapon;
        public InputAction @SkillPalette1 => m_Wrapper.m_Player_SkillPalette1;
        public InputAction @SkillPalette2 => m_Wrapper.m_Player_SkillPalette2;
        public InputAction @SkillPalette3 => m_Wrapper.m_Player_SkillPalette3;
        public InputAction @SkillPalette4 => m_Wrapper.m_Player_SkillPalette4;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @LightAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLightAttack;
                @LockTarget.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockTarget;
                @LockTarget.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockTarget;
                @LockTarget.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockTarget;
                @ReleaseLock.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReleaseLock;
                @ReleaseLock.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReleaseLock;
                @ReleaseLock.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReleaseLock;
                @SwitchWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchWeapon;
                @SkillPalette1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette1;
                @SkillPalette1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette1;
                @SkillPalette1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette1;
                @SkillPalette2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette2;
                @SkillPalette2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette2;
                @SkillPalette2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette2;
                @SkillPalette3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette3;
                @SkillPalette3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette3;
                @SkillPalette3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette3;
                @SkillPalette4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette4;
                @SkillPalette4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette4;
                @SkillPalette4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkillPalette4;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @LockTarget.started += instance.OnLockTarget;
                @LockTarget.performed += instance.OnLockTarget;
                @LockTarget.canceled += instance.OnLockTarget;
                @ReleaseLock.started += instance.OnReleaseLock;
                @ReleaseLock.performed += instance.OnReleaseLock;
                @ReleaseLock.canceled += instance.OnReleaseLock;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @SkillPalette1.started += instance.OnSkillPalette1;
                @SkillPalette1.performed += instance.OnSkillPalette1;
                @SkillPalette1.canceled += instance.OnSkillPalette1;
                @SkillPalette2.started += instance.OnSkillPalette2;
                @SkillPalette2.performed += instance.OnSkillPalette2;
                @SkillPalette2.canceled += instance.OnSkillPalette2;
                @SkillPalette3.started += instance.OnSkillPalette3;
                @SkillPalette3.performed += instance.OnSkillPalette3;
                @SkillPalette3.canceled += instance.OnSkillPalette3;
                @SkillPalette4.started += instance.OnSkillPalette4;
                @SkillPalette4.performed += instance.OnSkillPalette4;
                @SkillPalette4.canceled += instance.OnSkillPalette4;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardmouseSchemeIndex = -1;
    public InputControlScheme KeyboardmouseScheme
    {
        get
        {
            if (m_KeyboardmouseSchemeIndex == -1) m_KeyboardmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & mouse");
            return asset.controlSchemes[m_KeyboardmouseSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLightAttack(InputAction.CallbackContext context);
        void OnLockTarget(InputAction.CallbackContext context);
        void OnReleaseLock(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnSkillPalette1(InputAction.CallbackContext context);
        void OnSkillPalette2(InputAction.CallbackContext context);
        void OnSkillPalette3(InputAction.CallbackContext context);
        void OnSkillPalette4(InputAction.CallbackContext context);
    }
}
