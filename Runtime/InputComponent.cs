using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniFlux.Module.Input
{
    [Serializable] public class InputComponent
    {
        [SerializeField] private List<InputModel> Models = new List<InputModel>();
        private Action<string> OnInputId;
        //
        public void Subscribe(bool condition, Action<string> callback)
        {
            if(condition) OnInputId += callback;
            else OnInputId -= callback;
        }
        public void Update() 
        {
            for (int i = 0; i < Models.Count; i++) 
            {
                Models[i].CheckInput();
            }
        }
        public void Add((string id, KeyCode code, string method) data) 
        {
            Models.Add(new InputModel(data, OnInput));
        }
        public void Remove(string id)
        {
            Models.RemoveAll(k => string.Equals(id, k.Id));
        }
        public void Clear()
        {
            Models.Clear();
        }
        //
        private void OnInput(string id)
        {
            OnInputId?.Invoke(id);
        }
    }
}
