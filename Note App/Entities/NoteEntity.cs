using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_App.Entities
{
    internal class NoteEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public NoteEntity()
        {
            
        }
    }
}
