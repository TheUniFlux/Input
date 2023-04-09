using UnityEngine;
using Kingdox.UniFlux;

namespace UniFlux.Module.Input
{
    public sealed partial class InputModule : MonoFlux
    {
        [SerializeField] private InputComponent input = default;
        protected override void OnFlux(in bool condition)  
        {
            input.Subscribe(condition, OnInput);
        }
        void Update()  => input.Update();
        void OnInput(string id) => id.Dispatch();
        [Flux(InputData.Add)] void Add((string id, KeyCode code, string inputType) data) => input.Add(data);
        [Flux(InputData.Remove)] void Remove(string id) => input.Remove(id);
        [Flux(InputData.Clear)] void Clear() => input.Clear();
    }
}