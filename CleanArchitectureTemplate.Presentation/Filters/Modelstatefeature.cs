using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CleanArchitectureReferenceTemplate.Presentation.Filters
{
    public class Modelstatefeature
    {
        public ModelStateDictionary Modelstate { get; set; }

        public Modelstatefeature(ModelStateDictionary state)
        {
            this.Modelstate = state;
        }
    }
}
