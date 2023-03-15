//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/MainInput.inputactions
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

public partial class @MainInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInput"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""c192867d-3dba-42b2-986d-c7e8159db605"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""899c4999-f7eb-4c97-a59a-18e6d8d931a0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""cf12ba0d-5d0a-48d4-b2c1-804660be54ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""dodge"",
                    ""type"": ""Button"",
                    ""id"": ""94e5466e-57c6-428b-a1ea-fa690869e03d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""parry"",
                    ""type"": ""Button"",
                    ""id"": ""cd06342e-1348-49e5-9c42-3c876be43b65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""deflect"",
                    ""type"": ""Button"",
                    ""id"": ""890ba697-d0fc-4fc7-96f1-8e73546f99fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""counter"",
                    ""type"": ""Button"",
                    ""id"": ""6d7ab03d-7667-4e73-8081-e9c18e05c66b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""esc"",
                    ""type"": ""Button"",
                    ""id"": ""e12e794a-65de-4e1c-803f-25bd17fc1f3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""225d7d96-be20-4693-bc64-ae76e33031bd"",
                    ""path"": ""1DAxis(minValue=-3,maxValue=3)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""a827df58-d62f-45b5-b1d5-50b2378da084"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""d8f66431-8c6e-4dbb-89ef-d4e65fa84037"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""3c36410f-6bae-4167-8087-45cec33f5578"",
                    ""path"": ""1DAxis(minValue=-3,maxValue=3)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""b778a38e-cbd1-43a3-a11f-c5b17b49d1cf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""bcff6d73-6e2f-4ed8-bf1c-5cc2901b80f6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""368133ae-2ab6-4a76-b28f-623703c13deb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f18c2ec-16b6-4558-9e6d-17928ec70cff"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""840f758b-fff0-4cab-960f-72c1d56cb62b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a10057ad-c4ca-4298-b82a-df4f2ae908d1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""parry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""679a5286-f44c-4f81-a90b-2fc1379b8bd3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""deflect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53f84547-8568-4527-8efc-c9f4fa053ca1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""counter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90bdc019-4562-4a87-b998-66bc478ccff3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bf146d2-7738-4303-a31b-e03b25c92b8e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a32a42b-1ee8-449d-90d9-e20d3910bf18"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13d2862b-9305-4cb8-a185-5372932dfdb7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_move = m_Character.FindAction("move", throwIfNotFound: true);
        m_Character_jump = m_Character.FindAction("jump", throwIfNotFound: true);
        m_Character_dodge = m_Character.FindAction("dodge", throwIfNotFound: true);
        m_Character_parry = m_Character.FindAction("parry", throwIfNotFound: true);
        m_Character_deflect = m_Character.FindAction("deflect", throwIfNotFound: true);
        m_Character_counter = m_Character.FindAction("counter", throwIfNotFound: true);
        m_Character_esc = m_Character.FindAction("esc", throwIfNotFound: true);
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

    // Character
    private readonly InputActionMap m_Character;
    private List<ICharacterActions> m_CharacterActionsCallbackInterfaces = new List<ICharacterActions>();
    private readonly InputAction m_Character_move;
    private readonly InputAction m_Character_jump;
    private readonly InputAction m_Character_dodge;
    private readonly InputAction m_Character_parry;
    private readonly InputAction m_Character_deflect;
    private readonly InputAction m_Character_counter;
    private readonly InputAction m_Character_esc;
    public struct CharacterActions
    {
        private @MainInput m_Wrapper;
        public CharacterActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_Character_move;
        public InputAction @jump => m_Wrapper.m_Character_jump;
        public InputAction @dodge => m_Wrapper.m_Character_dodge;
        public InputAction @parry => m_Wrapper.m_Character_parry;
        public InputAction @deflect => m_Wrapper.m_Character_deflect;
        public InputAction @counter => m_Wrapper.m_Character_counter;
        public InputAction @esc => m_Wrapper.m_Character_esc;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @jump.started += instance.OnJump;
            @jump.performed += instance.OnJump;
            @jump.canceled += instance.OnJump;
            @dodge.started += instance.OnDodge;
            @dodge.performed += instance.OnDodge;
            @dodge.canceled += instance.OnDodge;
            @parry.started += instance.OnParry;
            @parry.performed += instance.OnParry;
            @parry.canceled += instance.OnParry;
            @deflect.started += instance.OnDeflect;
            @deflect.performed += instance.OnDeflect;
            @deflect.canceled += instance.OnDeflect;
            @counter.started += instance.OnCounter;
            @counter.performed += instance.OnCounter;
            @counter.canceled += instance.OnCounter;
            @esc.started += instance.OnEsc;
            @esc.performed += instance.OnEsc;
            @esc.canceled += instance.OnEsc;
        }

        private void UnregisterCallbacks(ICharacterActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @jump.started -= instance.OnJump;
            @jump.performed -= instance.OnJump;
            @jump.canceled -= instance.OnJump;
            @dodge.started -= instance.OnDodge;
            @dodge.performed -= instance.OnDodge;
            @dodge.canceled -= instance.OnDodge;
            @parry.started -= instance.OnParry;
            @parry.performed -= instance.OnParry;
            @parry.canceled -= instance.OnParry;
            @deflect.started -= instance.OnDeflect;
            @deflect.performed -= instance.OnDeflect;
            @deflect.canceled -= instance.OnDeflect;
            @counter.started -= instance.OnCounter;
            @counter.performed -= instance.OnCounter;
            @counter.canceled -= instance.OnCounter;
            @esc.started -= instance.OnEsc;
            @esc.performed -= instance.OnEsc;
            @esc.canceled -= instance.OnEsc;
        }

        public void RemoveCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    public interface ICharacterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnParry(InputAction.CallbackContext context);
        void OnDeflect(InputAction.CallbackContext context);
        void OnCounter(InputAction.CallbackContext context);
        void OnEsc(InputAction.CallbackContext context);
    }
}
