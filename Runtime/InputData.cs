using System;
using System.Collections.Generic;
using System.Linq;

namespace UniFlux.Module.Input
{
    public static class InputData
    {
        private const string KEY = nameof(Input) + ".";
        public const string Add = KEY + "Add";
        public const string Remove = KEY + "Remove";
        public const string Clear = KEY + "Clear";
        public const string OnInput = KEY + "OnInput.";
    }
}