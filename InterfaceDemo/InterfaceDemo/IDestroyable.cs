using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    interface IDestroyable
    {
        public string DestructionSound { get; set; }

        void Destroy();
    }
}
