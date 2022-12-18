﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.VisitorPattern
{
    public interface IVisitor
    {
        void Visit(Element element);
    }
}
