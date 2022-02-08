using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipedriveIntegration.DTO
{
    public class WebconElement
    {
        public Workflow workflow { get; set; }
        public FormType formType { get; set; }
        public ICollection<Field> formFields { get; set; }
    }
    public class Field
    {
        public Guid Guid { get; set; }
        public string Svalue { get; set; }
    }

    public class Workflow
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
    public class FormType
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
