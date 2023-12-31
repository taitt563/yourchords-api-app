﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Instruments.Commands.DeleteInstrument
{
    public class DeleteInstrumentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
