using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class M3 : BMW
    {
        public M3(int hP, string color, string model) : base(hP, color, model)
        {
            Model = model;
        }

        public sealed override void Repair()
        {
            base.Repair();
        }
    }
}
