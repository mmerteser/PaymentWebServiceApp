namespace Onix.Common.IntegratedApplications.Models.NebimV3.RequestModels
{
    public class NebimV3RunProcModel
    {
        public class Parameter
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public string ProcName { get; set; }
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
    }
}
