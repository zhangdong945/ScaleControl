using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Reports
{
    public class ReportLoader
    {
        private readonly IWeighingRepository _repository;

        public ReportLoader(IWeighingRepository repository)
        {
            _repository = repository;
        }

        public string GetTemplatePath(string reportType)
        {
            // TODO: 从数据库加载报表模板路径
            return $"Templates\\{reportType}.frx";
        }
    }
}
