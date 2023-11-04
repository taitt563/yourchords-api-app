using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Chords.Commands.DeleteChordById
{
    public class DeleteChordByIdCommand : IRequest<Unit>
    {
        public int ChordId { get; set; }
    }
}
