using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniFlux.Module.Input
{
    [Serializable] public struct InputModel
    {
        private static readonly Dictionary<string, Func<KeyCode, bool>> FUNCTIONS = new Dictionary<string, Func<KeyCode, bool>>()
        {
            [nameof(UnityEngine.Input.GetKey)] = (Code) => UnityEngine.Input.GetKey(Code),
            [nameof(UnityEngine.Input.GetKeyUp)] = (Code) => UnityEngine.Input.GetKeyUp(Code),
            [nameof(UnityEngine.Input.GetKeyDown)] = (Code) => UnityEngine.Input.GetKeyDown(Code),
        };
        //
        [SerializeField] private string _id;
        [SerializeField] private KeyCode _code;
        private Func<KeyCode, bool> _function;
        private Action<string> _onInput;
        //
        public string Id => _id;
        //
        public InputModel((string id, KeyCode code, string method) data, Action<string> onInput)
        {
            this._id = data.id;
            this._code = data.code;
            this._function = FUNCTIONS[data.method];
            this._onInput = onInput;
        }
        //
        public void CheckInput() 
        {
            if(_function(_code))
            {
                _onInput?.Invoke(_id);
            }
        }
    }
}